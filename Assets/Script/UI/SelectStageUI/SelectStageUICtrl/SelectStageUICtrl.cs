using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStageUICtrl : IUserInterfaceCtrl
{
    private SelectStageUI _view { get { return view as SelectStageUI; } }

    /// <summary>
    /// 关闭按钮的点击
    /// </summary>
    public void OnCloseBtnClick()
    {
        _view.Hide();
    }

    /// <summary>
    /// 选择了关卡
    /// </summary>
    /// <param name="stageInfo"></param>
    public void StageBegin(StageInfo stageInfo)
    {

        MainManager.Instance.StageBegin(stageInfo);

    }

}
