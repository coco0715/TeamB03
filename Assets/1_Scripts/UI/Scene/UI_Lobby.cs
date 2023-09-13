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
        GetText((int)Texts.PlayerLevelText).text = $"Lv.01";
        //$"{Managers.User.level}"
        GetText((int)Texts.PlayerNameText).text = Managers.User.name;
        GetImage((int)Images.PlayerImage).sprite = Resources.Load<Sprite>("Sprites/InGame/" + Managers.User.img);
        GetText((int)Texts.CoinText).text = "0";
            //Managers.User.coin.ToString();
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
