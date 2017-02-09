using System;
using UnityEngine;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

/// <summary>
/// 单例
/// </summary>
/// <typeparam name="T"></typeparam>
public class MonoSingleton<T> : MonoBehaviour
  where T : Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            return _instance;
        }
    }

    public virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
        }
    }
}

/// <summary>
/// Detail		:  工具类
/// Author		:  qingqing-zhao(569032731@qq.com)
/// CreateTime  :  #CreateTime#
/// </summary>
public class SDKUtils
{

    /// <summary>
    /// 汉字转换为Unicode编码
    /// </summary>
    /// <param name="str">要编码的汉字字符串</param>
    /// <returns>Unicode编码的的字符串</returns>
    public static string GBKToUnicode(string str)
    {
        string outStr = "";
        if (!string.IsNullOrEmpty(str))
        {
            for (int i = 0; i < str.Length; i++)
            {
                outStr += "/u" + ((int)str[i]).ToString("x");
            }
        }
        return outStr;
    }

    /// <summary>
    /// 将Unicode编码转换为汉字字符串
    /// </summary>
    /// <param name="str">Unicode编码字符串</param>
    /// <returns>汉字字符串</returns>
    public static string UnicodeToGBK(string str)
    {
        string outStr = "";
        if (!string.IsNullOrEmpty(str))
        {
            string[] strlist = str.Replace("/", "").Split('u');
            try
            {
                for (int i = 1; i < strlist.Length; i++)
                {
                    //将unicode字符转为10进制整数，然后转为char中文字符  
                    outStr += (char)int.Parse(strlist[i], System.Globalization.NumberStyles.HexNumber);
                }
            }
            catch (FormatException ex)
            {
                outStr = ex.Message;
            }
        }
        return outStr;
    }

    /// <summary>
    /// Recursively set the game object's layer.
    /// </summary>
    static public void SetLayer(GameObject go, int layer)
    {
        go.layer = layer;

        var t = go.transform;

        for (int i = 0, imax = t.childCount; i < imax; ++i)
        {
            var child = t.GetChild(i);
            SetLayer(child.gameObject, layer);
        }
    }

    /// <summary>
    /// 传入uri寻找指定控件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="findTrans"></param>
    /// <param name="uri"></param>
    /// <param name="isLog"></param>
    /// <returns></returns>
    public static T GetChildComponent<T>(Transform findTrans, string uri, bool isLog = true) where T : Component
    {
        Transform trans = findTrans.Find(uri);
        if (trans == null)
        {
            if (isLog)
                Debug.LogError("Get Child Error: " + uri);
            return default(T);
        }

        return (T)trans.GetComponent(typeof(T));
    }

    public static T GetChildComponent<T>(string uri, Transform findTrans, bool isLog = true) where T : Component
    {
        if (findTrans == null)
            return default(T);
        Transform trans = findTrans.FindChild(uri);
        if (trans == null)
        {
            if (isLog)
                Debug.LogError("Get Child Error: " + uri);
            return default(T);
        }

        return (T)trans.GetComponent(typeof(T));
    }


    public static GameObject GetChildGameobject(string uri, Transform findTrans, bool isLog = true)
    {
        Transform trans = GetChildComponent<Transform>(uri, findTrans, isLog);
        if (trans != null) return trans.gameObject;
        return null;
    }

    public static GameObject DFSFindObject(Transform parent, string name)
    {
        for (int i = 0; i < parent.childCount; ++i)
        {
            Transform node = parent.GetChild(i);
            if (node.name == name)
                return node.gameObject;

            GameObject target = DFSFindObject(node, name);
            if (target != null)
                return target;
        }

        return null;
    }

    public static GameObject GetGameObject(string name, Transform findTrans, bool isLog = true)
    {
        GameObject obj = DFSFindObject(findTrans, name);
        if (obj == null)
        {
            Debug.LogError("Find GemeObject Error: " + name);
            return null;
        }

        return obj;
    }

    public static void SetChild(GameObject child, GameObject parent, bool selfRotation = false, bool selfScale = false)
    {
        SetChild(child.transform, parent.transform, selfRotation, selfScale);
    }
    public static void SetChild(Transform child, Transform parent, bool selfRotation = false, bool selfScale = false)
    {
        child.parent = parent;
        ResetTransform(child, selfRotation, selfScale);
    }
    public static void ResetTransform(UnityEngine.Transform transform, bool selfRotation = false, bool selfScale = false)
    {
        transform.localPosition = UnityEngine.Vector3.zero;
        if (!selfRotation)
            transform.localEulerAngles = UnityEngine.Vector3.zero;

        if (!selfScale)
            transform.localScale = UnityEngine.Vector3.one;
    }

    //获取从父节点到自己的完整路径
    public static string GetRootPathName(UnityEngine.Transform transform)
    {
        var pathName = "/" + transform.name;
        while (transform.parent != null)
        {
            transform = transform.parent;
            pathName += "/" + transform.name;
        }
        return pathName;
    }

    public static string GetFileProtocol()
    {
        string fileProtocol = "file://";
        if (Application.platform == RuntimePlatform.WindowsEditor ||
            Application.platform == RuntimePlatform.WindowsPlayer
#if !UNITY_5_4_OR_NEWER
        || Application.platform == RuntimePlatform.WindowsWebPlayer
#endif
        )
        {
            fileProtocol = "file:///";
        }

        return fileProtocol;
    }
}

