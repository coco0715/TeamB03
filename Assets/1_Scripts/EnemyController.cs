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
        EnemySpeed = 2f;     // 왜 위에서는 안되고 여기서는 되는가.
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
        // 유니티에서 직접 집어넣는게 나은가..
    }


    private void Update()
    {
        Enemy.transform.position += new Vector3(0f, -1f, 0f) * Speed * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("충돌");
        if (coll.gameObject.tag == "Player")
        {
            // player.HP -= Damage;
            Destroy(Enemy);
        }
        // 이후, 플레이어 투사체 태그에 닿으면 사라지는 기능 구현
        // else if (coll.gameObject.tag == "bullet")
        //{
        //    Destroy(coll.gameObject);
        //}
    }
}
