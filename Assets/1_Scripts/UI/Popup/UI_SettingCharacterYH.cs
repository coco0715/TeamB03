using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SettingCharacterYH : UI_Popup
{
    enum GameObjects
    {
        UserNameInputField,
    }

    enum Texts
    {
        UserNameText,
    }

    enum Images
    {
        CharacterImage,
    }

    enum Buttons
    {
        DoneButton,
        BackButton,
        SettingButton,
    }

    void Start()
    {
        Init();
    }

    private void Update()
    {
        if (GetObject((int)GameObjects.UserNameInputField).gameObject.GetComponentInChildren<TMP_InputField>().text != "")
        {
            GetButton((int)Buttons.DoneButton).gameObject.SetActive(true);
        }
        else
        {
            GetButton((int)Buttons.DoneButton).gameObject.SetActive(false);
        }
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObject(typeof(GameObjects));
        BindText(typeof(Texts));
        BindImage(typeof(Images));
        BindButton(typeof(Buttons));

        GetObject((int)GameObjects.UserNameInputField).gameObject.GetComponentInChildren<TMP_InputField>().text = Managers.User.name;
        GetImage((int)Images.CharacterImage).sprite = Resources.Load<Sprite>("Sprites/InGame/" + Managers.User.img);

        GetComponent<Canvas>().sortingOrder = 10;
        GetObject((int)GameObjects.UserNameInputField).BindEvent(() => { 
            //Managers.Sound.Play("ClickBtnEff"); 
        });
        GetButton((int)Buttons.DoneButton).gameObject.BindEvent(() => {
            //Managers.Sound.Play("ClickBtnEff"); 
            OnClickedDoneButton();
        });
        GetButton((int)Buttons.BackButton).gameObject.BindEvent(() => {
            //로비 화면으로 이동
        });
        GetButton((int)Buttons.DoneButton).gameObject.BindEvent(() => {
            //설정 팝업 띄우기
        });
        GetImage((int)Images.CharacterImage).gameObject.BindEvent(() => {
            //Managers.Sound.Play("ClickBtnEff"); 
            OnClickedCharacterImg();
        });


        // Sound
        //Managers.Sound.Play("");

        return true;
    }

    void OnClickedDoneButton()
    {
        Managers.User.SetName(GetText((int)Texts.UserNameText).text);
        PlayerPrefs.SetString("UserName", Managers.User.name);
        if (Managers.Scene.CurrentSceneType == Define.Scene.MainScene)
        {
            GameObject.Find("UI_Main").GetComponent<UI_Main>().RefreshUI();
        }
        if (Managers.Scene.CurrentSceneType == Define.Scene.GameScene)
        {
            GameObject.Find("UI_Game").GetComponent<UI_Game>().SetOpnedSidePanel();
            GameObject.Find("Player").GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/InGame/" + Managers.User.img);
        }
        Managers.UI.ClosePopupUI(this);
    }

    void OnClickedCharacterImg()
    {
        Managers.UI.ClosePopupUI(this);
        Managers.UI.ShowPopupUI<UI_SettingImageYH>();
    }
}
