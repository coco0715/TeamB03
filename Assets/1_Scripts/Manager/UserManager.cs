using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager
{
    public string name = PlayerPrefs.GetString("UserName", "");
    public string img = PlayerPrefs.GetString("UserImg", "Jelly 0");

    public void SetName(string _name)
    {
        name = _name;
    }

    public void SetImg(string _img)
    { 
        img = _img; 
    }
}