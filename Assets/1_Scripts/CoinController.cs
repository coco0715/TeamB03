using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StageInformation;

public class CoinController : MonoBehaviour
{
    public Coin CoinObj;
    public Stage Stage;
    public int StageNum;
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

    }
    private void Start()
    {
        InvokeRepeating("DropCoins", 1f, 1f / CoinObj.GenCount);
    }
}
