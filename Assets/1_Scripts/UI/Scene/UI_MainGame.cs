using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainGame : UI_Scene
{
    enum Buttons
    {
        SettingButton,
    }
    enum Images
    {
        Heart1,
        Heart2,
        Heart3
    }
    enum Texts
    {
        TimeText,
        ValueText
    }
    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }


    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButton(typeof(Buttons));
        BindText(typeof(Texts));
        BindImage(typeof(Images));

        GetButton((int)Buttons.SettingButton).gameObject.BindEvent(OnClickedSettingButton);
        
        //�ʱ� �������� �ð� ��
        GetText((int)Texts.TimeText).text = "30";

        // Sound
        Managers.Sound.Clear();
        //Managers.Sound.Play("LobbyBgm", Define.Sound.Bgm);

        return true;
    }


    void OnClickedSettingButton()
    {
        //���� ��ư
    }
}