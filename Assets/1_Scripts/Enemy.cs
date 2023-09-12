using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Projectile
{ 
    //Stage stage
    //Player player
    public float EnemySpeed;
    public int Damage;

    public void SetEnemy()
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

        StartPosition = SetStartPosition();
        
        //Debug.Log($"Start Position : {StartPosition}");
    }

    private void Start()
    {
        SetEnemy();
        transform.position = StartPosition;
    }
    public void SetEnemySprite()
    {

    }

    private void Update()
    {
        transform.position += new Vector3(0f, -1f, 0f) * Speed * Time.deltaTime;
        if (this != null && this.transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("�浹");
            // player.HP -= Damage;
            Destroy(this.gameObject);
        }
        // ����, �÷��̾� ����ü �±׿� ������ ������� ��� ����
        // else if (coll.gameObject.tag == "bullet")
        //{
        //    Destroy(coll.gameObject);
        //}
    }
}
