using ImageDatas;
using StageInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Jiyeon : UI_Scene
{
    enum GameObjects
    {
        Content,
    }
    enum Buttons
    {
        BackButton,
    }

    void Start()
    {
        Init();
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        #region Bind
        BindObject(typeof(GameObjects));
        BindButton(typeof(Buttons));

        GetButton((int)Buttons.BackButton).gameObject.BindEvent(() => { Managers.Scene.ChangeScene(Define.Scene.LobbyScene); });
        #endregion

        for (int i = 0; i < Managers.GameManager.Stages.Count; i++)
        {
            Stage stage = Managers.GameManager.Stages[i];
            GameObject item = Managers.UI.MakeSubItem<UI_StageItem>(GetObject((int)GameObjects.Content).transform, "StageItem").gameObject;
            UI_StageItem stageItem = item.GetOrAddComponent<UI_StageItem>();
            if (stageItem.Init())
                stageItem.SetInfo(stage, i+1);
        }
        return true;
    }
}