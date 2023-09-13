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

        #region Bind
        BindImage(typeof(Images));
        BindText(typeof(Texts));
        BindButton(typeof(Buttons));

        GetButton((int)Buttons.SettingButton).gameObject.BindEvent(OnClickedSettingButton);
        GetButton((int)Buttons.RetryButton).gameObject.BindEvent(OnClickedRetryButton);
        GetButton((int)Buttons.NextLevelButton).gameObject.BindEvent(OnClickedNextLevelButton);
        GetButton((int)Buttons.LobbyButton).gameObject.BindEvent(OnClickedLobbyButton);
        #endregion

        //RefreshUI();

        return true;
    }

    //public void RefreshUI()
    //{
    //    int unlockedStageNum = Managers.User.UnlockedStageNum;
    //    GetText((int)Texts.PlayerLevelText).text = (unlockedStageNum < 9) ? $"Lv.0{unlockedStageNum}" : $"Lv.{unlockedStageNum}";
    //    GetText((int)Texts.PlayerNameText).text = Managers.User.name;
    //    GetImage((int)Images.PlayerImage).sprite = Resources.Load<Sprite>("Sprites/InGame/" + Managers.User.characterInfo.Img);
    //    GetText((int)Texts.CoinText).text = Managers.User.coin.ToString();
    //}

    void OnClickedSettingButton()
    {
        //Managers.Sound.Play("ClickBtnEff"); 
        Managers.Scene.ChangeScene(Define.Scene.SelectStageScene);
    }

    void OnClickedRetryButton()
    {
        //Managers.Sound.Play("ClickBtnEff"); 
        Managers.Scene.ChangeScene(Define.Scene.MainGameScene);
    }

    void OnClickedNextLevelButton()
    {
        //Managers.Sound.Play("ClickBtnEff"); 
        Managers.Scene.ChangeScene(Define.Scene.MainGameScene);
    }
    void OnClickedLobbyButton()
    {
        //Managers.Sound.Play("ClickBtnEff"); 
        Managers.Scene.ChangeScene(Define.Scene.LobbyScene);
    }
}
