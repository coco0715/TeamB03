using CharacterInformation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.TextCore.Text;

public class UserManager
{
    public string name = PlayerPrefs.GetString("UserName", "");
    public int characterIdx  = PlayerPrefs.GetInt("CharacterIdx", 0);
    public Characters characterInfo;
    public int coin = PlayerPrefs.GetInt("Coin", 0);

    public int score = 0;
    static int comboCount = 0;

    public int UnlockedStageNum = PlayerPrefs.GetInt("UnlockedStageNum", 1);
    public int Hp;

    public void initScore()
    {
        score = 0;
    }

    public void PlusScore()
    {
        if(comboCount == 0)
        {
            score += 10;
        }
        else if(comboCount == 1)
        {
            score += 15;
        }
        else if (comboCount == 2)
        {
            score += 17;
        }
        else if (comboCount >= 3)
        {
            score += 20;
        }
        comboCount++;
        if(score > 10000)
        {
            score = 10000;
        }
    }

    public void NotCombo()
    {
        comboCount = 0;
    }

    public void Init()
    {
        characterInfo = Managers.GameManager.Characters[characterIdx];
        Hp = characterInfo.Hp;
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