using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tips : MonoBehaviour
{

    public Button btn;
    public Text txt;

    public static bool isShow = false;

    private static Tips instance;

    private Action btnCallback = null;

    public static Tips Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.Find("Tips").GetComponent<Tips>();
            }
            return instance;
        }
    }

    private void Start()
    {
        btn.onClick.AddListener(() => {
            Hide();
            btnCallback?.Invoke();
        });
    }

    public void ReSetTextContent(string s)
    {
        txt.text = s;
    }

    public void ReSetBtnCallback(Action action)
    {
        btnCallback = action;
    }

    public void Show()
    {
        isShow = true;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        isShow = false;
        gameObject.SetActive(false);
    }

}
