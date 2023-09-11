using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EnemyController : ProjectileController
{
    //Stage stage
    //Player player
    public float EnemySpeed;
    public GameObject Enemy;
    public int Damage;

    private void Awake()
    {
        // GenCoeff = Stage.GenCountCoeff;
        // SetCount();
        GenCount = 3;

        // SpeedCoeff = Stage.EnemySpeedCoeff;
        EnemySpeed = 2f;     // �� �������� �ȵǰ� ���⼭�� �Ǵ°�.
        Speed = EnemySpeed;
        SpeedCoeff = 1.0f;
        SetSpeed();

        // ScaleCoeff = Stage.EnemyScaleCoeff;
        ScaleCoeff = 1.0f;
        SetScale();

        SetStartPosition(Enemy);
    }

    public void SetEnemy()
    {
        Instantiate(Enemy);
    }

    public void SetDamage()
    {
        // ����Ƽ���� ���� ����ִ°� ������..
    }


    private void Update()
    {
        Enemy.transform.position += new Vector3(0f, -1f, 0f) * Speed * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("�浹");
        if (coll.gameObject.tag == "Player")
        {
            // player.HP -= Damage;
            Destroy(Enemy);
        }
        // ����, �÷��̾� ����ü �±׿� ������ ������� ��� ����
        // else if (coll.gameObject.tag == "bullet")
        //{
        //    Destroy(coll.gameObject);
        //}
    }
}
