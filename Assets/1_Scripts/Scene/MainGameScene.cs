using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameScene : BaseScene
{
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        SceneType = Define.Scene.MainScene;
        Managers.UI.ShowSceneUI<UI_MainGame>();
        Debug.Log("Enter MainGame");
        return true;
    }
}