using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanaScene : BaseScene
{
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        SceneType = Define.Scene.HanaScene;
        Managers.UI.ShowSceneUI<UI_Hana>();
        return true;
    }
}
