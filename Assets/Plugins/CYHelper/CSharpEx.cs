using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 扩展C#的方法
/// </summary>
public static class CSharpEx  {
    //以下扩展方法Kengine中已有，但在Plugins
    public static byte ToByte(this string val)
    {
        byte ret = 0;
        try
        {
            if (!String.IsNullOrEmpty(val))
            {
                ret = Convert.ToByte(val);
            }
        }
        catch (Exception)
        {
        }
        return ret;
    }

    public static long ToInt64(this string val)
    {
        long ret = 0;
        try
        {
            if (!String.IsNullOrEmpty(val))
            {
                ret = Convert.ToInt64(val);
            }
        }
        catch (Exception)
        {
        }
        return ret;
    }

    public static float ToFloat(this string val)
    {
        float ret = 0;
        try
        {
            if (!String.IsNullOrEmpty(val))
            {
                ret = Convert.ToSingle(val);
            }
        }
        catch (Exception)
        {
        }
        return ret;
    }

    static public Int32 ToInt32(this string str)
    {
        Int32 ret = 0;

        try
        {
            if (!String.IsNullOrEmpty(str))
            {
                ret = Convert.ToInt32(str);
            }
        }
        catch (Exception)
        {
        }
        return ret;
    }

    public static Int32 ToInt32(this object obj)
    {
        Int32 ret = 0;
        try
        {
            if (obj != null)
            {
                ret = Convert.ToInt32(obj);
            }
        }
        catch (Exception)
        {
        }

        return ret;
    }

    /// <summary>
    /// Get from object Array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="openArgs"></param>
    /// <param name="offset"></param>
    /// <param name="isLog"></param>
    /// <returns></returns>
    //public static T Get<T>(this object[] openArgs, int offset, bool isLog = true)
    //{
    //	T ret;
    //	if ((openArgs.Length - 1) >= offset)
    //	{
    //		var arrElement = openArgs[offset];
    //		if (arrElement == null)
    //			ret = default(T);
    //		else
    //		{
    //			try
    //			{

    //				ret = (T)Convert.ChangeType(arrElement, typeof(T));
    //			}
    //			catch (Exception)
    //			{
    //				if (arrElement is string && String.IsNullOrEmpty(arrElement as string))
    //					ret = default(T);
    //				else
    //				{
    //					//LogWriter.WriteError("[Error get from object[],  '{0}' change to type {1}", arrElement, typeof(T));
    //					ret = default(T);
    //				}
    //			}

    //		}
    //	}
    //	else
    //	{
    //		ret = default(T);
    //		if (isLog)
    //		{
    //			//LogWriter.WriteError("[GetArg] {0} args - offset: {1}", openArgs, offset);
    //		}
    //	}

    //	return ret;
    //}

    //public static void ResizeBoxCollider(this BoxCollider boxCollider, UIWidget widget)
    //{
    //	if (widget != null)
    //	{
    //		boxCollider.size = new Vector3(widget.width, widget.height, 0);
    //	}
    //}

    /// <summary>
    /// .net4.0 stringbuild 会有Clear 函数，到时可以删掉这个函数
    /// </summary>
    /// <param name="sb"></param>
    public static void Clear(this StringBuilder sb)
    {
        sb.Length = 0;
    }


    /// <summary>
    /// 尝试将键和值添加到字典中：如果不存在，才添加；存在，不添加也不抛导常
    /// </summary>
    public static Dictionary<TKey, TValue> TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
    {
        if (dict.ContainsKey(key) == false) dict.Add(key, value);
        return dict;
    }

    /// <summary>
    /// 将键和值添加或替换到字典中：如果不存在，则添加；存在，则替换
    /// </summary>
    public static Dictionary<TKey, TValue> AddOrReplace<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
    {
        if (dict.ContainsKey(key) == false)
        {
            dict.Add(key, value);
        }
        else
        {
            dict[key] = value;
        }
        return dict;
    }

}
