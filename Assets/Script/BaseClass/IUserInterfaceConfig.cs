public class IUserInterfaceConfig 
{
    public IUserInterface View;
    public IUserInterfaceCtrl Ctrl;
    public IUserInterfaceModel Model;
    public ENUM_UILayer layer;
    public string prefab_Path = string.Empty;

    public void  InitConfig()
    {
        View.ctrl = Ctrl;

        View.model = Model; 

        Model.view = View;

        Ctrl.view = View;

        Ctrl.model = Model;
    }
}
