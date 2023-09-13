using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StageInformation;
using UnityEditor;

public class CoinController : MonoBehaviour
{
    public Coin CoinObj;
    public Stage Stage;
    public int StageNum;

    public float CoinSpeed;
    public int CoinGenCount;
    public Vector3 CoinScale;
    private void DropCoins()
    {
        CoinObj.SetCoin();
        if (CoinObj != null)
        {
            Instantiate(CoinObj);
        }
    }
    private void Awake()
    {
        StageNum = Managers.GameManager.StageNum;
        Stage = Managers.GameManager.Stages[StageNum];
        CoinSpeed = Stage.EnemySpeedCoeff * 1f;
        CoinGenCount = (int)Stage.EnemyGenCountCoeff;
    }
    private void Start()
    {
        InvokeRepeating("DropCoins", 1f, 1f / CoinGenCount);
    }
}
