using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HeartItem : UI_Base
{
    enum Images
    {
        HeartItem,
    }

    public override bool Init()
    {

        if (base.Init() == false)
            return false;

        BindImage(typeof(Images));

        return true;
    }

    public void SetInfo(bool isDead = false)
    {
        if (isDead)
        {
            GetImage((int)Images.HeartItem).color = Color.grey;
        }
    }
}