using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Lobby : UI_Scene
{
    enum Images
    {
        PlayerImage,
    }
    enum Texts
    {
        PlayerNameText,
        PlayerLevelText,
        CoinText,
    }
    enum Buttons
    {
        StartButton,
        QuitButton, 
        SettingButton,
        SettingCharacterButton,
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

        GetButton((int)Buttons.SettingCharacterButton).gameObject.BindEvent(OnClickedSettingCharacterButton);
        GetButton((int)Buttons.StartButton).gameObject.BindEvent(OnClickedStartButton);
        GetButton((int)Buttons.QuitButton).gameObject.BindEvent(OnClickedQuiteButton);
        #endregion

        RefreshUI();

        return true;
    }

    public void RefreshUI()
    {
        int unlockedStageNum = Managers.User.UnlockedStageNum;
        GetText((int)Texts.PlayerLevelText).text = (unlockedStageNum < 9) ? $"Lv.0{unlockedStageNum}" : $"Lv.{unlockedStageNum}";
        GetText((int)Texts.PlayerNameText).text = Managers.User.name;
        GetImage((int)Images.PlayerImage).sprite = Resources.Load<Sprite>("Sprites/InGame/" + Managers.User.characterInfo.Img);
        GetText((int)Texts.CoinText).text = Managers.User.coin.ToString();
    }

    void OnClickedStartButton()
    {
        //Managers.Sound.Play("ClickBtnEff"); 
        Managers.Scene.ChangeScene(Define.Scene.SelectStageScene);
    }

    void OnClickedQuiteButton()
    {
        //Managers.Sound.Play("ClickBtnEff"); 
        Application.Quit();
    }

    void OnClickedSettingCharacterButton()
    {
        //Managers.Sound.Play("ClickBtnEff"); 
        Managers.UI.ShowPopupUI<UI_SettingCharacterYH>();
    }
}
