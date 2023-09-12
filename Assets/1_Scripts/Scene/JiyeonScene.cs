using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JiyeonScene : BaseScene
{
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        SceneType = Define.Scene.JiyeonScene;
        Managers.UI.ShowSceneUI<UI_Jiyeon>();
        Debug.Log("Enter Main");
        return true;
    }
}