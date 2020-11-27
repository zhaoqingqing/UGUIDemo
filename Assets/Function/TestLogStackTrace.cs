using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using KEngine;
using UnityEngine.Serialization;

/// <summary>
/// 作者：赵青青 (569032731@qq.com)
/// 时间：#CreateTime#
/// 说明：
/// </summary>
public class TestLogStackTrace : MonoBehaviour
{
    public Button btn1;
    public Button btn2;
    public Button btn3;
    private Text text1;

    // Use this for initialization
    void Start()
    {
        btn1.onClick.AddListener(OnClickBtn1);
        btn2.onClick.AddListener(OnClickBtn2);

        LogFileManager.Start();
    }


    void OnClickBtn1()
    {
       MyFunc1();
       MyFunc2();
        //test exception 
        text1.text = "text";
    }

    void OnClickBtn2()
    {
        Debug.Log("test  log");
        Debug.LogWarning("test  log warn");
        Debug.LogError("test  log error");
        Debug.LogAssertion("test  log assert");
        //test exception 
        text1.text = "text";
    }

    void MyFunc1()
    {
        Debug.Log(this.name + "click stacktrace:\n" + new StackTrace(true) + "\n");
    }

    void MyFunc2()
    {
        Debug.Log(this.name + "click stackframe:\n" + new StackFrame(true) + "\n");
    }

    void Destory()
    {
        LogFileManager.Destory();
    }
}