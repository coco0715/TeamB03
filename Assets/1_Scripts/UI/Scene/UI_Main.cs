using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Main : UI_Scene
{
    enum Images
    {
        PlayerImage,
    }
    enum Texts
    {
        NameText,
    }
    enum Buttons
    {
        EnterButton,
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

        RefreshUI();
        GetButton((int)Buttons.EnterButton).gameObject.BindEvent(OnClickedEnterButton);

        Managers.UI.ShowPopupUI<UI_SettingCharacter>();

        // Sound
        Managers.Sound.Clear();
        //Managers.Sound.Play("LobbyBgm", Define.Sound.Bgm);

        return true;
    }

    public void RefreshUI()
    {
        GetText((int)Texts.NameText).text = Managers.User.name;
        GetImage((int)Images.PlayerImage).sprite = Resources.Load<Sprite>("Sprites/InGame/" + Managers.User.characterInfo.Img);
    }

    void OnClickedEnterButton()
    {
        Managers.Scene.ChangeScene(Define.Scene.GameScene);
    }
}