using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoungHyunScene : BaseScene
{
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        SceneType = Define.Scene.YoungHyunScene;
        Managers.UI.ShowSceneUI<UI_YoungHyun>();
        Debug.Log("Enter YoungHyun");
        return true;
    }
}