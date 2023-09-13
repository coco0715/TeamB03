using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameJYScene : BaseScene
{
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        SceneType = Define.Scene.MainGameJYScene;
        Managers.UI.ShowSceneUI<UI_MainGame>();
        Debug.Log("Enter MainGame");
        return true;
    }
}
