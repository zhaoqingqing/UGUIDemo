using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// 快速提示信息 for ugui
/// 需要导入Dotween
/// </summary>
public class XUIMidMsg : MonoBehaviour
{
    public const int MSG_LIMIT = 3; // 最大显示的消息条数
    public const float MSG_TIME = 1.5f; // 持续时间
    public const float FADE_TIME = 0.4f; // 渐变效果时间
    public const float MSG_HEIGHT = 100f; // 向上的位移

    private Stack<XUIMidMsgAnimator> m_MsgTempllatePool;  // 内存池
    public List<XUIMidMsgAnimator> m_WaitingMsgList = new List<XUIMidMsgAnimator>();  // waiting List... wait for 1-5 seconds

    public GameObject MsgTemplate;

    private bool IsInit = false;

    private static XUIMidMsg instance;
    public static XUIMidMsg Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType(typeof(XUIMidMsg)) as XUIMidMsg;
                if (instance == null)
                {
                    //初始化
                    GameObject obj = new GameObject("XUIMidMsg");
                    var uiRoot = GameObject.FindObjectOfType<Canvas>();
                    if (uiRoot)
                    {
                        obj.AddComponent<Canvas>();
                        obj.transform.SetParent(uiRoot.transform);
                        obj.transform.ResetLocal();
                    }
                    else
                    {
                        Debug.LogError("当前场景找不到任何Canvas");
                    }
                    instance = obj.AddComponent<XUIMidMsg>();
                    instance.MsgTemplate = Resources.Load("MsgTemplate") as GameObject;
                    instance.OnInit();
                }
            }
            return instance;
        }
    }

    /// <summary>
    ///  静态方法， 快速弹信息
    /// </summary>
    /// <param name="msgStr"></param>
    public static void QuickMsg(string msgStr, params object[] args)
    {
        Instance.OnInit();
        Instance.ShowMsg(string.Format(msgStr, args));
    }

    public void Awake()
    {
        OnInit();
    }

    public void OnInit()
    {
        if (!IsInit)
        {
            m_MsgTempllatePool = new Stack<XUIMidMsgAnimator>();
            var msgTemplate = UnityHelper.GetChildComponent<Transform>(transform, "MsgTemplate", false);
            if (msgTemplate)
            {
                MsgTemplate = msgTemplate.gameObject;
                MsgTemplate.gameObject.SetActive(false);
            }

            IsInit = true;
        }
    }


    public void ShowMsg(string msgStr)
    {
        Debug.Assert(MsgTemplate);
        if (gameObject.activeSelf == false) gameObject.SetActive(true);
        if (m_WaitingMsgList.Count == MSG_LIMIT)  // 超过限制了，隐藏第一个，并从等待列表中移除
        {
            XUIMidMsgAnimator msgSave = m_WaitingMsgList[0];
            m_WaitingMsgList.RemoveAt(0);
            msgSave.StopAnimate(); // 先停止其显示协程
            msgSave.StartCoroutine(msgSave.WaitMsgDelete());  // 让其渐变淡出
        }

        // 将之前的，向上移位，并缩放效果
        m_WaitingMsgList.ForEach((msgSave) =>
        {
            Vector3 startPos = msgSave.transform.localPosition;  // 如果正在移位中...那么取当前移位结果位置进行下一步位移
            var endPos = startPos + new Vector3(0, MSG_HEIGHT, 0);
            msgSave.transform.DOLocalMove(endPos, FADE_TIME);

            Vector3 startScale = msgSave.transform.localScale;  // 如果正在缩放中...那么取当前缩放结果位置进行下一步缩放
            Vector3 endScale = startScale * 0.95f;
            msgSave.transform.DOScale(endScale, FADE_TIME);
        });

        XUIMidMsgAnimator msgInstance = PoolGet();

        // 开始执行动画~
        m_WaitingMsgList.Add(msgInstance);
        msgInstance.StartAnimate(msgStr);
    }

    public void PoolDelete(XUIMidMsgAnimator msgInstance)
    {
        msgInstance.gameObject.SetActive(false);
        m_MsgTempllatePool.Push(msgInstance);
    }

    public XUIMidMsgAnimator PoolGet()
    {
        XUIMidMsgAnimator msgInstance = null;
        if (m_MsgTempllatePool.Count > 0)
            msgInstance = m_MsgTempllatePool.Pop();

        if (msgInstance == null)
        {
            GameObject newGameObj = GameObject.Instantiate(MsgTemplate) as GameObject;
            msgInstance = newGameObj.AddComponent<XUIMidMsgAnimator>();
            msgInstance.transform.SetParent(this.transform);
            msgInstance.UICtrler = this;
        }


        UnityHelper.ResetTransform(msgInstance.transform);
        msgInstance.gameObject.SetActive(true);

        return msgInstance;
    }
}