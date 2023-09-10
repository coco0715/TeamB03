using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class UI_InGameCharacter : UI_Base
{
    enum GameObjects
    {
        InGameCharacter,
    }
    enum Images
    {
        Image,
    }
    enum Texts
    {
        NameText,
    }

    public override bool Init()
    {

        if (base.Init() == false)
            return false;

        BindObject(typeof(GameObjects));
        BindImage(typeof(Images));
        BindText(typeof(Texts));

        return true;
    }

    public void SetInfo(string img, string name)
    {
        GetImage((int)Images.Image).sprite = Resources.Load<Sprite>(img);
        Debug.Log(Resources.Load<Sprite>(img));
        GetText((int)Texts.NameText).text = name;
    }

    public void SetInfo(int img, string name)
    {
        GetImage((int)Images.Image).sprite = Resources.LoadAll<Sprite>("Sprites/npcPortrait")[img];
        GetText((int)Texts.NameText).text = name;
    }
}
