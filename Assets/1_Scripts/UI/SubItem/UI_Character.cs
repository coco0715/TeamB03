using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Character : UI_Base
{
    enum GameObjects
    {
        Character,
    }
    enum Images
    {
        Image,
    }

    public override bool Init()
    {

        if (base.Init() == false)
            return false;

        BindObject(typeof(GameObjects));
        BindImage(typeof(Images)); 

        return true;
    }

    public void SetInfo(string img)
    {
        GetImage((int)Images.Image).sprite = Resources.Load<Sprite>("Sprites/InGame/" + img);
    }
}
