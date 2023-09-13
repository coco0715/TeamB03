using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StageInformation;

public class Coin : Projectile
{
    public float CoinSpeed;
    public Stage Stage;
    public int StageNum;

    public void SetCoin()
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

        StartPosition = SetStartPosition();
    }
    private void Start()
    {
        transform.position = StartPosition;
    }
    private void Update()
    {
        transform.position += new Vector3(0f, -1f, 0f) * Speed * Time.deltaTime;
        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        // ���� ����
        // Score = GameManager.Instance.Score;
        
        if (coll.gameObject.tag == "Player")
        {
            // player.Score += 10;  // ���� �޺��ý��ۿ� ���� ���� �߰��ؾ��ҵ�?
            Debug.Log("10�� �߰�");
            Destroy(this.gameObject);
        }
    }
}
