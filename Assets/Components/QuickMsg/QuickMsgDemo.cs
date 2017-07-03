using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Detail		:  Desc
/// Author		:  qingqing-zhao(569032731@qq.com)
/// CreateTime  :  #CreateTime#
/// </summary>
public class QuickMsgDemo : MonoBehaviour
{
    public Button BtnTest;
    public int MsgIndex = 0;

    // Use this for initialization
    void Start()
    {
        BtnTest.onClick.AddListener(OnQuickMsg);
    }


    void OnQuickMsg()
    {
        XUIMidMsg.QuickMsg("test - " + MsgIndex);
        MsgIndex += 1;
    }
}
