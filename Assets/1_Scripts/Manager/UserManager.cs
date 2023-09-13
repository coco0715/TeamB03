using CharacterInformation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class UserManager
{
    public string name = PlayerPrefs.GetString("UserName", "");
    public int characterIdx  = PlayerPrefs.GetInt("CharacterIdx", 0);
    public Characters characterInfo;
    public int coin = PlayerPrefs.GetInt("Coin", 0);
    public int score = 0;
    public int UnlockedStageNum = PlayerPrefs.GetInt("UnlockedStageNum", 1);

    public void Init()
    {
        characterInfo = Managers.GameManager.Characters[characterIdx];
    }

    public void SetCharacterInfo(Characters _characterInfo)
    {
        characterInfo = _characterInfo;
    }

    public void SetName(string _name)
    {
        name = _name;
    }

    public void SetCoin(int _coin)
    {
        if(_coin > 10000)
        {
            _coin = 10000;
        }
        if(_coin < 0) 
        { 
            _coin = 0;
        }
        coin = _coin;
    }
}