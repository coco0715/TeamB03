using ImageDatas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainGame : UI_Scene
{
    public float Timer = 30f;
    int MaxHp;

    #region Enums
    enum GameObjects
    {
        Hearts,
    }
    enum Buttons
    {
        SettingButton,
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
        Invoke("CountingTimer", 3f);
    }

    void Update()
    {
        if(Managers.GameManager.IsStartedTimer)
        {
            CountingTimer();
        }
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObject(typeof(GameObjects));
        BindButton(typeof(Buttons));
        BindText(typeof(Texts));

        GetButton((int)Buttons.SettingButton).gameObject.BindEvent(OnClickedSettingButton);

        RefreshHeart();

        MaxHp = Managers.User.characterInfo.Hp;
        // Sound
        Managers.Sound.Clear();
        //Managers.Sound.Play("LobbyBgm", Define.Sound.Bgm);
        return true;
    }

    void CountingTimer()
    {
        Timer -= Time.deltaTime;
        RefreshUI();

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

    void RefreshUI()
    {
        RefreshHeart();
        GetText((int)Texts.TimeText).text = Timer.ToString("N2");
        GetText((int)Texts.ValueText).text = string.Format("{0:#,###}",Managers.User._score.ToString());
    }

    void RefreshHeart()
    {
        foreach (Transform child in GetObject((int)GameObjects.Hearts).transform)
            Managers.Resource.Destroy(child.gameObject);

        for (int i = 1; i <= MaxHp; i++)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_HeartItem>(GetObject((int)GameObjects.Hearts).transform, "HeartItem").gameObject;
            UI_HeartItem heart = item.GetOrAddComponent<UI_HeartItem>();
            if (heart.Init())
            {
                if(Managers.User.Hp < i)
                {
                    heart.SetInfo(false);
                }
            }
        }
    }

    void OnClickedSettingButton()
    {
        //세팅 버튼
    }
}