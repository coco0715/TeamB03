using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Hana : UI_Scene
{
    enum Images
    {
        PlayerImage,
    }
    enum Texts
    {
        PlayerNameText,
        PlayerLevelText,
        ScoreText,
        ResultText,
    }
    enum Buttons
    {
        SettingButton,
        RetryButton,
        NextLevelButton,
        LobbyButton,
    }

    void Start()
    {
        Init();
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindImage(typeof(Images));
        BindText(typeof(Texts));
        BindButton(typeof(Buttons));

        GetButton((int)Buttons.SettingButton).gameObject.BindEvent(OnClickedSettingButton);
        GetButton((int)Buttons.RetryButton).gameObject.BindEvent(OnClickedRetryButton);
        GetButton((int)Buttons.NextLevelButton).gameObject.BindEvent(OnClickedNextLevelButton);
        GetButton((int)Buttons.LobbyButton).gameObject.BindEvent(OnClickedLobbyButton);

        return true;
    }

    void OnClickedSettingButton()
    {
        Managers.Scene.ChangeScene(Define.Scene.SelectStageScene);
    }

    void OnClickedRetryButton()
    {
        Managers.Scene.ChangeScene(Define.Scene.MainGameScene);
    }

    void OnClickedNextLevelButton()
    {
        Managers.Scene.ChangeScene(Define.Scene.MainGameScene);
    }

    void OnClickedLobbyButton()
    {
        Managers.Scene.ChangeScene(Define.Scene.LobbyScene);
    }
}