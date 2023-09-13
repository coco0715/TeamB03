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
    public int coin;
    public int score;
    public void SetCharacterInfo(Characters _characterInfo)
    {
        characterInfo = _characterInfo;
    }
    public void SetName(string _name)
    {
        name = _name;
    }

    public void Init()
    {
        characterInfo = Managers.GameManager.Characters[characterIdx];
    }

}