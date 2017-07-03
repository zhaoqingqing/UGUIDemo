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
