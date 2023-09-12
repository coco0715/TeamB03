using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public Coin CoinObj;
    private void DropCoins()
    {
        CoinObj.SetCoin();
        if (CoinObj != null)
        {
            Instantiate(CoinObj);
        }
    }

    private void Start()
    {
        InvokeRepeating("DropCoins", 1f, 0.5f);
    }
}
