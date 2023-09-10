using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using ImageDatas;

public class UI_SettingImage : UI_Popup
{
    List<ImageData> imageData = new List<ImageData> ();

    enum GameObjects
    {
        Content,
    }

    enum Texts
    {
        TitleText,
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
        BindText(typeof(Texts));
        BindImage(typeof(Images));
        BindButton(typeof(Buttons));

        GetText((int)Texts.TitleText).text = "캐릭터 변경";
        GetButton((int)Buttons.DoneButton).gameObject.BindEvent(() => {
            //Managers.Sound.Play("ClickBtnEff"); 
            OnClickedDoneButton();
        });
        GetImage((int)Images.CharacterImage).sprite = Resources.Load<Sprite>("Sprites/InGame/" + PlayerPrefs.GetString("UserImg", "Jelly 0"));

        imageData = Managers.JsonReader.ReadCharacterImageJson("Assets/Resources/Data/imageData.json").ImageDataList;

        for (int i = 0; i < imageData.Count; i++)
        {
            string imgName = imageData[i].imgName;
            GameObject item = Managers.UI.MakeSubItem<UI_Character>(GetObject((int)GameObjects.Content).transform, "Character").gameObject;
            item.BindEvent(() => {
                //Managers.Sound.Play("ClickBtnEff");
                OnClickedImage(imgName);
             });
            UI_Character character = item.GetOrAddComponent<UI_Character>();
            if (character.Init())
                character.SetInfo(imgName);
        }

        // Sound
        //Managers.Sound.Play("");

        return true;
    }

    void OnClickedDoneButton()
    {
        Managers.User.SetImg(GetImage((int)Images.CharacterImage).sprite.name.Replace("(UnityEngine.Sprite)", ""));
        PlayerPrefs.SetString("UserImg", Managers.User.img);
        Managers.UI.ClosePopupUI(this);
        Managers.UI.ShowPopupUI<UI_SettingCharacter>();
    }

    void OnClickedImage(string imgName)
    {
        GetImage((int)Images.CharacterImage).sprite = Resources.Load<Sprite>("Sprites/InGame/" + imgName);
    }
}
