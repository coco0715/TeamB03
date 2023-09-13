using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainGame : UI_Scene
{
    public float Timer = 30f;
    bool initialized = false;
    #region Enums
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
    #endregion

    void Start()
    {
        Init();
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        GetText((int)Texts.TimeText).text = Timer.ToString("N2");

        if (Timer < 10.0f)
        {
            GetText((int)Texts.TimeText).color = Color.red;
        }

        if (Timer <= 0.0f)
        {
            Timer = 0f;
            GetText((int)Texts.TimeText).text = "0";
            //Managers.UI.ShowPopupUI<UI_Result>();
            Time.timeScale = 0.0f;
        }
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButton(typeof(Buttons));
        BindText(typeof(Texts));
        BindImage(typeof(Images));

        GetButton((int)Buttons.SettingButton).gameObject.BindEvent(OnClickedSettingButton);
        
        //초기 스테이지 시간 값
        GetText((int)Texts.TimeText).text = "30";

        // Sound
        Managers.Sound.Clear();
        //Managers.Sound.Play("LobbyBgm", Define.Sound.Bgm);
        initialized = true;
        return true;
    }


    void OnClickedSettingButton()
    {
        //세팅 버튼
    }
}