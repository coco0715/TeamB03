using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EnemyController : ProjectileController
{
    //Stage stage
    public float EnemySpeed = 2f;
    public GameObject Enemy;
    public EnemyController(Stage stage)
    {
        // EnemyInfo.GenCoeff = Stage.GenCountCoeff;
        // EnemyInfo.SpeedCoeff = Stage.EnemySpeedCoeff;
        // EnemyInfo.ScaleCoeff = Stage.EnemyScaleCoeff;
        Speed = EnemySpeed;
    }

    public void SetEnemy()
    {
        SetSpeed();
        SetCount();
        SetScale();
    }

    private void Start()
    {
        SetStartPosition(Enemy);
    }

    private void Update()
    {
        Debug.Log(Speed);
        Enemy.transform.position += new Vector3(0f, -1f, 0f) * Time.deltaTime;
    }

    public void OnTrigeerEnter2D(Collider2D coll)
    {
        Debug.Log("�浹");
        if (coll.gameObject.tag == "Player")
        {
            // player.HP -= 1f;
            Destroy(coll.gameObject);
        }
        // ����, �÷��̾� ����ü �±׿� ������ ������� ��� ����
        // else if (coll.gameObject.tag == "bullet")
        //{
        //    Destroy(coll.gameObject);
        //}
    }
}
