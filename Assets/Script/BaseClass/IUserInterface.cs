using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// 玩家界面的共同父类，包含一个指向PBDG对象的类成员
/// 在其下的子类都能通过这个成员向PBDG发出需求
/// </summary>
public abstract class IUserInterface
{
    protected GameObject m_RootUI = null;
    private bool m_bActive = true;

    public IUserInterfaceCtrl ctrl;

    public IUserInterfaceModel model;

    public bool IsVisible()
    {
        return m_bActive;
    }

    public virtual void Show()
    {
        m_RootUI.SetActive(true);
        m_bActive = true;
    }

    public virtual void Hide()
    {
        m_RootUI.SetActive(false);
        m_bActive = false;
    }

    public virtual void Initialize(string prefabPath) { }
    public virtual void Release() { }
    public virtual void Update() { }

    public Transform GetThisUIRoot()
    {
        return m_RootUI.transform;
    }

    public void SetParent(Transform popUp, bool v=false)
    {
        m_RootUI.transform.SetParent(popUp,v);
    }
}
