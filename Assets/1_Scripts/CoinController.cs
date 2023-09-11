using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : ProjectileController
{
    public float CoinSpeed;
    public GameObject Coin;
    //public int Score;

    private void Awake()
    {
        // GenCoeff = Stage.GenCountCoeff;
        // SetCount();
        GenCount = 3;

        // SpeedCoeff = Stage.CoinSpeedCoeff;
        CoinSpeed = 1.5f;     // �� �������� �ȵǰ� ���⼭�� �Ǵ°�.
        Speed = CoinSpeed;
        SpeedCoeff = 1.0f;
        SetSpeed();

        // ScaleCoeff = Stage.EnemyScaleCoeff;
        ScaleCoeff = 1.0f;
        SetScale();

        SetStartPosition(Coin);
    }

    private void Update()
    {
        Coin.transform.position += new Vector3(0f, -1f, 0f) * Speed * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        // ���� ����
        // Score = GameManager.Instance.Score;
        
        if (coll.gameObject.tag == "Player")
        {
            // player.Score += 10;  // ���� �޺��ý��ۿ� ���� ���� �߰��ؾ��ҵ�?
            Debug.Log("10�� �߰�");
            Destroy(Coin);
        }
        // ����, �÷��̾� ����ü �±׿� ������ ������� ��� ����
        // else if (coll.gameObject.tag == "bullet")
        //{
        //    Destroy(coll.gameObject);
        //}
    }
}
