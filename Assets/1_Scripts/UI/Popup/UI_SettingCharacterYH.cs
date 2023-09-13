using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class UI_SettingCharacterYH : UI_Popup
{
    enum GameObjects
    {
        UserNameInputField,
        ErrorToast
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
            //로비 화면으로 이동
        });
        GetButton((int)Buttons.DoneButton).gameObject.BindEvent(() => {
            //설정 팝업 띄우기
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
        string nameString = GetText((int)Texts.UserNameText).text;

        if (CheckValidName(nameString))
        {
            Managers.User.SetName(GetText((int)Texts.UserNameText).text);
            PlayerPrefs.SetString("UserName", Managers.User.name);
            Managers.UI.ClosePopupUI(this);
        }
        else
        {
            StartCoroutine(CONotValidNamePopup());
        }
        
    }

    void OnClickedCharacterImg()
    {
        Managers.UI.ClosePopupUI(this);
        Managers.UI.ShowPopupUI<UI_SettingImageYH>();
    }

    bool CheckValidName(string name)
    {
        int count = 0;
        name.TrimEnd('\0', '\r', '\n', ' ');

        foreach (char c in name)
        {
            if (c != 32)
            {
                count++;
            }
            else
            {
                break;
            }
            Debug.Log(c);
            if (!(char.IsLetter(c) || char.IsDigit(c) || (0xAC00 <= c && c <= 0xD7A3)))
            {
                return false;
            }
        }

        Debug.Log(count);
        if (count >= 2 && count <= 10)
        {
            return true;
        }
        return false;
    }

    IEnumerator CONotValidNamePopup()
    {
        GetObject((int)GameObjects.ErrorToast).SetActive(true);
        yield return new WaitForSeconds(1.5f);
        GetObject((int)GameObjects.ErrorToast).SetActive(false);
    }
    
}
