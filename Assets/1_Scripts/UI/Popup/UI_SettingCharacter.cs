using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class UI_SettingCharacter : UI_Popup
{
    #region Enums
    enum GameObjects
    {
        UserNameInputField,
        ErrorToast
    }

    enum Texts
    {
        UserNameText,
        ErrorToastText,
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
    #endregion
    void Start()
    {
        Init();
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObject(typeof(GameObjects));
        BindText(typeof(Texts));
        BindImage(typeof(Images));
        BindButton(typeof(Buttons));

        GetObject((int)GameObjects.ErrorToast).SetActive(false);
        GetObject((int)GameObjects.UserNameInputField).gameObject.GetComponentInChildren<TMP_InputField>().text = Managers.User.name;
        GetImage((int)Images.CharacterImage).sprite = Resources.Load<Sprite>("Sprites/InGame/" + Managers.User.characterInfo.Img);

        GetComponent<Canvas>().sortingOrder = 10;

        GetButton((int)Buttons.DoneButton).gameObject.BindEvent(() => {
            OnClickedDoneButton();
        });
        GetButton((int)Buttons.BackButton).gameObject.BindEvent(() => {
            Managers.UI.ClosePopupUI(this);
        });
        GetImage((int)Images.CharacterImage).gameObject.BindEvent(() => {
            OnClickedCharacterImg();
        });

        // Sound
        //Managers.Sound.Play("");

        return true;
    }

    void OnClickedDoneButton()
    {
        if (CheckValidName(GetObject((int)GameObjects.UserNameInputField).gameObject.GetComponentInChildren<TMP_InputField>().text))
        {
            StartCoroutine(CONotValidNamePopup("이름을 변경했습니다."));
            Managers.User.SetName(GetText((int)Texts.UserNameText).text);
            PlayerPrefs.SetString("UserName", Managers.User.name);
            GameObject.Find("UI_Lobby").GetComponent<UI_Lobby>().RefreshUI();
            Managers.UI.ClosePopupUI(this);
        }
    }

    void OnClickedCharacterImg()
    {
        Managers.UI.ClosePopupUI(this);
        Managers.UI.ShowPopupUI<UI_SettingImage>();
    }

    bool CheckValidName(string name)
    {
        bool result = true;
        int length = name.Length;

        if (length < 2 || length > 10)
        {
            StartCoroutine(CONotValidNamePopup("이름은 2 ~ 10 글자여야 합니다."));
            return false;
        }

        string check = "`~!@#$%^&*()_+-+=[]{}:;\"\'\\,<.>/?";

        for (int i = 0; i < length; i++)
        {
            if (check.Contains(name.Substring(i, 1)))
            {
                StartCoroutine(CONotValidNamePopup("특수 문자는 사용할 수 없습니다."));
                result = false;
                break;
            }
        }
        return result;
    }

    IEnumerator CONotValidNamePopup(string content)
    {
        GetObject((int)GameObjects.ErrorToast).SetActive(true);
        GetText((int)Texts.ErrorToastText).text = content;
        yield return new WaitForSeconds(1.5f);
        GetObject((int)GameObjects.ErrorToast).SetActive(false);
    }
}