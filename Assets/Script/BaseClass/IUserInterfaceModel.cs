using UnityEngine;
using System.Collections;


public abstract class IUserInterfaceModel
{
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
