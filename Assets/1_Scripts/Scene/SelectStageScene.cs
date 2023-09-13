using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStageScene : BaseScene
{
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        SceneType = Define.Scene.SelectStageScene;
        Managers.UI.ShowSceneUI<UI_SelectStage>();
        return true;
    }
}