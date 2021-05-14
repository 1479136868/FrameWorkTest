public class MainUIConfig : IUserInterfaceConfig
{
    public MainUIConfig() 
    {
        prefab_Path = "MainUI";

        View = new MainUI();
        Ctrl = new MainUICtrl();
        Model = new MainUIModel();

        layer = ENUM_UILayer.Normal;
        InitConfig();
    }
}
