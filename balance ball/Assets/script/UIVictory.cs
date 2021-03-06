using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIVictory : MonoBehaviour
{
    public victory _victory;
    public Button restart_button;
    private bool IsWin;
    // Start is called before the first frame update
    void Start()
    {

        //隐藏ui
        GetComponent<CanvasGroup>().alpha = 0;
        GetComponent<CanvasGroup>().interactable = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        _victory._win+= Onwin;//调用PlayerControl类，订阅Player的死亡事件
        restart_button.onClick.AddListener(onclick);
    }

    private void onclick()
    {
        SceneManager.LoadScene("SampleScene"); //重新载入场景
        Debug.Log("click btn");
        Time.timeScale = 1;
    }

    private void Onwin(bool temp)
    {
        IsWin = temp;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsWin) //如果游戏结束显示ui
        {
            GetComponent<CanvasGroup>().alpha = 1;
            GetComponent<CanvasGroup>().interactable = true;
            GetComponent<CanvasGroup>().blocksRaycasts = true;

            Time.timeScale = 0;
        }
    }
}
