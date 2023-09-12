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
    public float timeAccumulate;

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
        
        //Debug.Log($"Start Position : {StartPosition}");
    }

    private void Start()
    {
        SetEnemy();
        transform.position = StartPosition;

        timeAccumulate = 0f;
    }

    private void Update()
    {
        if (Pool == null)
            return;
        timeAccumulate += Time.deltaTime;
        linearPos(Speed, timeAccumulate);
        //BezierPos(Speed, timeAccumulate);
        //transform.position += new Vector3(0f, -1f, 0f) * Speed * Time.deltaTime;

        if (this != null && this.transform.position.y < -6f)
        {
            //Destroy(this.gameObject);
            Pool.Release(this.gameObject);
        }
    }

    private void linearPos(float speed, float time)
    {
        transform.position = Vector3.down * speed * time + StartPosition;
    }

    private void BezierPos(float speed, float time)
    {
        Vector3[] points = new Vector3[4];
        points[0] = StartPosition;
        points[1] = new Vector3(Random.Range(-2.7f, 2.7f), StartPosition.y, 0);
        points[2] = new Vector3(Random.Range(-2.7f, 0f), StartPosition.y - 12, 0);
        points[3] = new Vector3(Random.Range(0f, 2.7f), StartPosition.y - 12, 0);
        Vector3 bezierPosition;
        for (float t = 0; t < 1; t = (time * speed) / 10)
        {
            bezierPosition = Mathf.Pow(1 - t, 3) * points[0]
                + Mathf.Pow(1 - t, 2) * 3 * points[1]
                + Mathf.Pow(t, 2) * 3 * points[2]
                + Mathf.Pow(t, 3) * points[3];

            transform.position = bezierPosition;
        }
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
