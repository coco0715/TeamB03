using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_YoungHyun : UI_Scene
{
    enum Buttons
    {
        PopupButton,
    }

    void Start()
    {
        Init();
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButton(typeof(Buttons));

        GetButton((int)Buttons.PopupButton).gameObject.BindEvent(OnClickedPopupButton);

        // Sound
        Managers.Sound.Clear();
        //Managers.Sound.Play("LobbyBgm", Define.Sound.Bgm);

        return true;
    }


    void OnClickedPopupButton()
    {
        Managers.UI.ShowPopupUI<UI_SettingCharacterYH>();
    }
}