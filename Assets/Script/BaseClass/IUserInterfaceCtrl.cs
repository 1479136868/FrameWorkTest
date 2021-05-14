using UnityEngine;
using System.Collections;


public abstract class IUserInterfaceCtrl
{
    /// <summary>
    /// 数据模型类
    /// </summary>
    public IUserInterfaceModel model = null;
    
    /// <summary>
    /// 界面
    /// </summary>
    public IUserInterface view = null;

    public virtual void Initialize() { }
    public virtual void OnEnable() { }
    public virtual void OnDisable() { }
    public virtual void Release() { }
    public virtual void Update() { }
}
