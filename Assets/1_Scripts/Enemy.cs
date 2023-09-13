using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;
using StageInformation;

public class Enemy : Projectile
{
    public Stage Stage;

    public int StageNum;
    //Player player
    public float EnemySpeed;
    public int Damage;

    private Vector3 FirstPoint;
    private Vector3 SecondPoint;
    private Vector3 ThirdPoint;

    public IObjectPool<GameObject> Pool { get; set; }

    public void SetEnemy()
    {
        //GenCoeff = 1.0f;
        SetCount();
        EnemySpeed = 2f;     // 왜 위에서는 안되고 여기서는 되는가.
        Speed = EnemySpeed;
        //SpeedCoeff = 1.0f;
        SetSpeed();
        //ScaleCoeff = 1.0f;
        SetScale();

        StartPosition = SetStartPosition();

        InitTime();
    }

    private void Awake()
    {
        Managers.GameManager.Init();
        StageNum = Managers.GameManager.StageNum - 1;
        Stage = Managers.GameManager.Stages[StageNum];

        GenCoeff = (int)Stage.EnemyGenCountCoeff;
        SpeedCoeff = Stage.EnemySpeedCoeff;
        ScaleCoeff = Stage.EnemyScaleCoeff;

        SetEnemy();
        transform.position = StartPosition;
        SetRandomPoint();

        Debug.Log(StartPosition);
        Debug.Log(Speed);
        Debug.Log(_Scale);
    }

    //private void Start()
    //{
    //    SetEnemy();
    //    transform.position = StartPosition;
    //    SetRandomPoint();
    //}

    private void Update()
    {
        if (Pool == null)
            return;
        TimeAccumulate += Time.deltaTime;
        //LinearPos(Speed, TimeAccumulate);
        BezierPos(Speed, TimeAccumulate);

        //transform.position += new Vector3(0f, -1f, 0f) * Speed * Time.deltaTime;

        if (this != null && this.transform.position.y < -5.5f)
        {
            Debug.Log("Down");
            Pool.Release(this.gameObject);
        }
    }

    private void LinearPos(float speed, float time)
    {
        transform.position = (speed * time * Vector3.down) + StartPosition;
    }

    private void SetRandomPoint()
    {
        FirstPoint = new Vector3(Random.Range(-2.7f, 2.7f), StartPosition.y, 0);
        SecondPoint = new Vector3(FirstPoint.x, StartPosition.y - 12, 0);
        ThirdPoint = new Vector3(StartPosition.x, StartPosition.y - 12, 0);
    }
    private void BezierPos(float speed, float time)
    {       
        Vector3[] points = new Vector3[4];
        // !! Random 값을 줘버리면, 매 프레임마다 값이 변함.
        points[0] = StartPosition;
        points[1] = FirstPoint;
        points[2] = SecondPoint;
        points[3] = ThirdPoint;
        Vector3 bezierPosition;
        float t = (time / (12 * 1.7f /speed));
        bezierPosition = CalculateBezierPosition(points, t);
        Vector3 tangentPos;
        tangentPos = CalculateTangent(points, t);
    

        // Math.Sin || Math.Cos || PingPong (등속도) ==
        transform.position = bezierPosition;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, tangentPos);
    }
    private Vector3 CalculateBezierPosition(Vector3[] points, float t)
    {
        Vector3 first = Vector3.Lerp(points[0], points[1], t);
        Vector3 Second = Vector3.Lerp(points[1], points[2], t);
        Vector3 third = Vector3.Lerp(points[2], points[3], t);

        Vector3 FNS = Vector3.Lerp(first, Second, t);
        Vector3 SNT = Vector3.Lerp(Second, third, t);
        Vector3 ansPos;
        ansPos = Vector3.Lerp(FNS, SNT, t);
        return ansPos;
    }
    private Vector3 CalculateTangent(Vector3[] points, float t)
    {
        float deltaT = t + 0.01f;
        Vector3 currentPos = CalculateBezierPosition(points, t);
        Vector3 nextPos = CalculateBezierPosition(points, deltaT);
        Vector3 tangent = (nextPos - currentPos).normalized;
        Vector3 fixedTangent = Quaternion.Euler(0, 0, 270) * tangent * -1;
        return fixedTangent;
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("충돌");
            Debug.Log($"데미지 : {Damage}");
            Managers.User.Hp -= Damage;
            Pool.Release(this.gameObject);
        }
        //이후, 플레이어 투사체 태그에 닿으면 사라지는 기능 구현
         else if (coll.gameObject.tag == "Bullet")
        {
            Destroy(coll.gameObject);
            Destroy(this.gameObject);
        }
    }
}
