using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterInformation;
using UnityEngine.U2D;

public class UI_Character : UI_Base
{
    public Characters _characters;
    public int _characterIdx;

    enum Images
    {
        Image,
    }

    public override bool Init()
    {

        if (base.Init() == false)
            return false;

        BindImage(typeof(Images)); 

        return true;
    }

    public void SetInfo(int idx)
    {
        _characters = Managers.GameManager.Characters[idx];
        _characterIdx = idx;
        if (_characters.IsLocked)
        {
            GetImage((int)Images.Image).sprite = Resources.Load<Sprite>("Sprites/UI/Lock");
            GetImage((int)Images.Image).color = Color.black;
        }
        else
        {
            GetImage((int)Images.Image).sprite = Resources.Load<Sprite>("Sprites/InGame/" + _characters.Img);
            GetImage((int)Images.Image).color = Color.white;
        }
    }
}
