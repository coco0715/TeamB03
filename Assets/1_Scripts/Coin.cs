using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StageInformation;

public class Coin : Projectile
{
    public float CoinSpeed;
    public int CoinGenCount;
    public Vector3 CoinScale;

    public Stage Stage;
    public int StageNum;


    public void SetCoin()
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

        StartPosition = SetStartPosition();
    }
    private void Start()
    {
        StageNum = Managers.GameManager.StageNum;
        Stage = Managers.GameManager.Stages[StageNum];
        CoinSpeed = Stage.EnemySpeedCoeff * 1f;
        CoinGenCount = (int)Stage.EnemyGenCountCoeff;
        CoinScale = Stage.CoinScaleCoeff * new Vector3(1f, 1f, 1f);

        transform.position = StartPosition;
        transform.localScale = CoinScale;
    }
    private void Update()
    {
        transform.position += new Vector3(0f, -1f, 0f) * CoinSpeed * Time.deltaTime;
        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        // 점수 연결
        // Score = GameManager.Instance.Score;
        
        if (coll.gameObject.tag == "Player")
        {
            // player.Score += 10;  // 코인 콤보시스템에 의한 점수 추가해야할듯?
            Debug.Log("10점 추가");
            Destroy(this.gameObject);
        }
    }
}
