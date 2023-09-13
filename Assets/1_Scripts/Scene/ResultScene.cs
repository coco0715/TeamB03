using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScene : BaseScene
{
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        SceneType = Define.Scene.ResultScene;
        Managers.UI.ShowSceneUI<UI_Result>();
        return true;
    }
}
