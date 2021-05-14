using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagUICtrl : IUserInterfaceCtrl
{
    BagUI _view { get { return view as BagUI; } }

    public void OnCloseBtnClick()
    {
        _view.Hide();
    }
}
