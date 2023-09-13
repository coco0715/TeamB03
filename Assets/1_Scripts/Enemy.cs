using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : Projectile
{ 
    //Stage stage
    //Player player
    public float EnemySpeed;
    public int Damage;

    private Vector3 FirstPoint;
    private Vector3 SecondPoint;
    private Vector3 ThirdPoint;

    //private float TimeAccumulate;

    public IObjectPool<GameObject> Pool { get; set; }

    public void SetEnemy()
    {
        // GenCoeff = Managers.GameManagers.stages[Managers.GameManager.stageNum].GenCountCoeff;
        // SetCount();
        GenCount = 3;

        // SpeedCoeff = Stage.EnemySpeedCoeff;
        EnemySpeed = 2f;     // 왜 위에서는 안되고 여기서는 되는가.
        Speed = EnemySpeed;
        SpeedCoeff = 1.0f;
        SetSpeed();

        // ScaleCoeff = Stage.EnemyScaleCoeff;
        ScaleCoeff = 1.0f;
        SetScale();

        StartPosition = SetStartPosition();
    }

    private void Start()
    {
        SetEnemy();
        transform.position = StartPosition;
        SetRandomPoint();
        //TimeAccumulate = 0f;
    }

    private void Update()
    {
        if (Pool == null)
            return;
        //TimeAccumulate += Time.deltaTime;
        //linearPos(Speed, timeAccumulate);
        //BezierPos(Speed, timeAccumulate);
        
        transform.position += new Vector3(0f, -1f, 0f) * Speed * Time.deltaTime;

        if (this != null && this.transform.position.y < -6f)
        {
            Pool.Release(this.gameObject);
        }
    }

    private void linearPos(float speed, float time)
    {
        transform.position = (Vector3.down * speed * time) + StartPosition;
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
        // Math.Sin || Math.Cos || PingPong (등속도) ==
        Vector3 first = Vector3.Lerp(points[0], points[1], t);
        Vector3 Second = Vector3.Lerp(points[1], points[2], t);
        Vector3 third = Vector3.Lerp(points[2], points[3], t);

        Vector3 FNS = Vector3.Lerp(first, Second, t);
        Vector3 SNT = Vector3.Lerp(Second, third, t);
        bezierPosition = Vector3.Lerp(FNS,SNT, t);
        transform.position = bezierPosition;

    }
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("충돌");
            Debug.Log($"데미지 : {Damage}");
            // player.HP -= Damage;
            Pool.Release(this.gameObject);
        }
        // 이후, 플레이어 투사체 태그에 닿으면 사라지는 기능 구현
        // else if (coll.gameObject.tag == "bullet")
        //{
        //    Destroy(coll.gameObject);
        //}
    }
}
