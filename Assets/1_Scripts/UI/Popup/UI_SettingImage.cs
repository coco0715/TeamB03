using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using ImageDatas;
using CharacterInformation;
using UnityEngine.TextCore.Text;

public class UI_SettingImage : UI_Popup
{
    public List<Characters> _characters = new List<Characters>();
    public int Index;
    Characters Character;

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
        BackButton,
        SettingButton
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

        GetButton((int)Buttons.BackButton).gameObject.BindEvent(() => {
            //Managers.Sound.Play("ClickBtnEff"); 
            OnClickedBackButton();
        });

        GetButton((int)Buttons.SettingButton).gameObject.BindEvent(() => {
            //Managers.Sound.Play("ClickBtnEff"); 
            OnClickedSettingButton();
        });


        Character = Managers.User.characterInfo;
        Index = PlayerPrefs.GetInt("CharacterIdx");

        GetImage((int)Images.CharacterImage).sprite = Resources.Load<Sprite>("Sprites/InGame/" + Managers.User.characterInfo.Img);

        _characters = Managers.GameManager.Characters;
        for (int i = 0; i < _characters.Count; i++)
        {
            string imgName = _characters[i].Img;
            GameObject item = Managers.UI.MakeSubItem<UI_Character>(GetObject((int)GameObjects.Content).transform, "Character").gameObject;
            item.BindEvent(() => {
                OnClickedImage(item.GetComponent<UI_Character>());
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
        PlayerPrefs.SetInt("CharacterIdx", Index);
        Managers.User.SetCharacterInfo(Character);
        Managers.UI.ClosePopupUI(this);
        Managers.UI.ShowPopupUI<UI_SettingCharacter>();
    }

    void OnClickedBackButton()
    {
        Managers.UI.ClosePopupUI(this);
        Managers.UI.ShowPopupUI<UI_SettingCharacter>();
    }

    void OnClickedSettingButton()
    {
        //Setting btn
    }

    void OnClickedImage(UI_Character uI_Character)
    {
        if (uI_Character._characters.IsLocked)
        {
            if(Managers.User.coin >= 1000)
            {
                Managers.User.coin -= 1000;
                PlayerPrefs.SetInt("Coin", Managers.User.coin);
                _characters[uI_Character._characterIdx].IsLocked = false;
                CharacterData characterData = new CharacterData();
                characterData.CharacterInfoList = _characters;
                Managers.JsonWriter.WriteCharacterDataJson(characterData, "Assets/Resources/Data/characterData.json");
                uI_Character.SetInfo(uI_Character._characterIdx);
            }
        }
        else
        {
            Character = uI_Character._characters;
            Index = uI_Character._characterIdx;
            GetImage((int)Images.CharacterImage).sprite = Resources.Load<Sprite>("Sprites/InGame/" + _characters[Index].Img);
        }
    }
}
