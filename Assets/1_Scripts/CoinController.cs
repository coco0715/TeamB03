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
        CoinSpeed = 1.5f;     // 왜 위에서는 안되고 여기서는 되는가.
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
        // 점수 연결
        // Score = GameManager.Instance.Score;
        
        if (coll.gameObject.tag == "Player")
        {
            // player.Score += 10;  // 코인 콤보시스템에 의한 점수 추가해야할듯?
            Debug.Log("10점 추가");
            Destroy(Coin);
        }
        // 이후, 플레이어 투사체 태그에 닿으면 사라지는 기능 구현
        // else if (coll.gameObject.tag == "bullet")
        //{
        //    Destroy(coll.gameObject);
        //}
    }
}
