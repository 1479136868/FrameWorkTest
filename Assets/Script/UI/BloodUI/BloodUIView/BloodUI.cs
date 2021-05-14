using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 血量界面(提供给怪物)
/// </summary>
public class BloodUI : IUserInterface
{
    private Slider currentSlider = null;


    public override void Initialize(string s)
    { 
        m_RootUI = UnityTool.FindGameObject(s);

        currentSlider = UITool.GetUIComponent<Slider>(m_RootUI, "Slider");

    }

    public void SetCurrentEnemy(EnemyAttr attr)
    {
        if (attr!=null)
        {
            currentSlider.maxValue = attr.GetMaxHP();
            currentSlider.value = attr.GetNowHP();
            if (currentSlider.value ==0)
            {
                IUserInterfaceManager.GetInstance().CloseUI(typeof(BloodUIConfig));
            }
            return;
        }
        Debug.LogError("EnemyAttr异常！！！");
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Release()
    {
        base.Release();
    }

    public override void Show()
    {
        base.Show();
    }

    public override void Hide()
    {
        base.Hide();
    }


}
