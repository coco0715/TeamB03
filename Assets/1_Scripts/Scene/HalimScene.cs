public class HalimScene : BaseScene
{
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        SceneType = Define.Scene.HalimScene;
        Managers.UI.ShowSceneUI<UI_Halim>();
        return true;
    }
}
