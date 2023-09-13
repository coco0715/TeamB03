using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using ImageDatas;
using CharacterInformation;

public class UI_SettingImageYH : UI_Popup
{
    public List<Characters> _characters;

    enum GameObjects
    {
        Content,
    }

    enum Images
    {
        CharacterImage,
    }

    enum Buttons
    {
        DoneButton,
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
        BindImage(typeof(Images));
        BindButton(typeof(Buttons));

        GetButton((int)Buttons.DoneButton).gameObject.BindEvent(() => {
            //Managers.Sound.Play("ClickBtnEff"); 
            OnClickedDoneButton();
        });
        GetImage((int)Images.CharacterImage).sprite = Resources.Load<Sprite>("Sprites/InGame/" + PlayerPrefs.GetString("UserImg", "Jelly 0"));

        _characters = Managers.GameManager.Characters;
        for (int i = 0; i < _characters.Count; i++)
        {
            string imgName = _characters[i].Img;
            GameObject item = Managers.UI.MakeSubItem<UI_Character>(GetObject((int)GameObjects.Content).transform, "Character").gameObject;
            item.BindEvent(() => {
                OnClickedImage(item.GetComponent<UI_Character>()._characters);
             });
            UI_Character character = item.GetOrAddComponent<UI_Character>();
            if (character.Init())
                character.SetInfo(i);
        }

        // Sound
        //Managers.Sound.Play("");

        return true;
    }

    void OnClickedDoneButton()
    {
        Managers.UI.ClosePopupUI(this);
        Managers.UI.ShowPopupUI<UI_SettingCharacterYH>();
    }

    void OnClickedImage(Characters _characters)
    {
        Managers.User.SetCharacterInfo(_characters);
        GetImage((int)Images.CharacterImage).sprite = Resources.Load<Sprite>("Sprites/InGame/" + Managers.User.characterInfo.Img);
    }
}
