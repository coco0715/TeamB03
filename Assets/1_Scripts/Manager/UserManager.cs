using CharacterInformation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.TextCore.Text;

public class UserManager
{
    public string name = PlayerPrefs.GetString("UserName", "");
    public int characterIdx  = PlayerPrefs.GetInt("CharacterIdx", 0);
    public Characters characterInfo;
    public int coin = PlayerPrefs.GetInt("Coin", 0);

    public int _score = 0;
    static int _comboCount = 0;

    public int UnlockedStageNum = PlayerPrefs.GetInt("UnlockedStageNum", 1);
    public int Hp;

    public void initScore()
    {
        _score = 0;
    }

    public void plusScore()
    {
        if(_comboCount == 0)
        {
            _score += 10;
        }
        else if(_comboCount == 1)
        {
            _score += 15;
        }
        else if (_comboCount == 2)
        {
            _score += 17;
        }
        else if (_comboCount >= 3)
        {
            _score += 20;
        }
        _comboCount++;
    }

    public void NotCombo()
    {
        _comboCount = 0;
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