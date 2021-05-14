using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGameManager 
{ 
    /// <summary>
    /// 初始化
    /// </summary>
    public virtual void Initinal() { }

    /// <summary>
    /// 注销
    /// </summary>
    public virtual void Release() { }
    
    /// <summary>
    /// 更新
    /// </summary>
    public virtual void Update() { }
}
