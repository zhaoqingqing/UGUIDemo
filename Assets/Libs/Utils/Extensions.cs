using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public static class Extensions
{
	public static Vector2 ToVector2(this Vector3 vec)
	{
		return new Vector2(vec.x, vec.y);
	}

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

	static public string ToString(this object obj)
	{
		var ret = "";
		if (obj != null)
			ret = obj.ToString();
		return ret;
	}

	static public bool SetActive(this Transform trans, bool active)
	{
		var ret = false;
		if (trans != null)
		{
			trans.gameObject.SetActive(active);
			ret = true;
		}
		return ret;
	}
	static public bool SetActiveX(this GameObject obj, bool active)
	{
		var ret = false;
		if (obj != null)
		{
			obj.SetActive(active);
			ret = true;
		}
		return ret;
	}

	public static void SetPositionX(this Transform t, float newX)
	{
		t.position = new Vector3(newX, t.position.y, t.position.z);
	}

	public static void SetPositionY(this Transform t, float newY)
	{
		t.position = new Vector3(t.position.x, newY, t.position.z);
	}

	public static void SetLocalPositionX(this Transform t, float newX)
	{
		t.localPosition = new Vector3(newX, t.localPosition.y, t.localPosition.z);
	}
	public static void SetLocalPositionY(this Transform t, float newY)
	{
		t.localPosition = new Vector3(t.localPosition.x, newY, t.localPosition.z);
	}

	public static void SetLocalPositionYAdd(this Transform t, float newY)
	{
		t.localPosition = new Vector3(t.localPosition.x, t.GetLocalPositionY() + newY, t.localPosition.z);
	}
	public static void SetPositionZ(this Transform t, float newZ)
	{
		t.position = new Vector3(t.position.x, t.position.y, newZ);
	}
	public static void SetLocalPositionZ(this Transform t, float newZ)
	{
		t.localPosition = new Vector3(t.localPosition.x, t.localPosition.y, newZ);
	}

	public static void SetLocalScale(this Transform t, Vector3 newScale)
	{
		t.localScale = newScale;
	}
	public static void SetLocalScaleZero(this Transform t)
	{
		t.localScale = Vector3.zero;
	}
	public static float GetPositionX(this Transform t)
	{
		return t.position.x;
	}

	public static float GetPositionY(this Transform t)
	{
		return t.position.y;
	}

	public static float GetPositionZ(this Transform t)
	{
		return t.position.z;
	}

	public static float GetLocalPositionX(this Transform t)
	{
		return t.localPosition.x;
	}

	public static float GetLocalPositionY(this Transform t)
	{
		return t.localPosition.y;
	}

	public static float GetLocalPositionZ(this Transform t)
	{
		return t.localPosition.z;
	}
	public static bool HasRigidbody(this GameObject gobj)
	{
		return (gobj.GetComponent<Rigidbody>() != null);
	}

	public static bool HasAnimation(this GameObject gobj)
	{
		return (gobj.GetComponent<Animation>() != null);
	}

	public static void SetSpeed(this Animation anim, float newSpeed)
	{
		anim[anim.clip.name].speed = newSpeed;
	}

	/// <summary>
	/// Get from object Array
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="openArgs"></param>
	/// <param name="offset"></param>
	/// <param name="isLog"></param>
	/// <returns></returns>
	public static T Get<T>(this object[] openArgs, int offset, bool isLog = true)
	{
		T ret;
		if ((openArgs.Length - 1) >= offset)
		{
			var arrElement = openArgs[offset];
			if (arrElement == null)
				ret = default(T);
			else
			{
				try
				{

					ret = (T)Convert.ChangeType(arrElement, typeof(T));
				}
				catch (Exception)
				{
					if (arrElement is string && String.IsNullOrEmpty(arrElement as string))
						ret = default(T);
					else
					{
						//LogWriter.WriteError("[Error get from object[],  '{0}' change to type {1}", arrElement, typeof(T));
						ret = default(T);
					}
				}

			}
		}
		else
		{
			ret = default(T);
			if (isLog)
			{
				//LogWriter.WriteError("[GetArg] {0} args - offset: {1}", openArgs, offset);
			}
		}

		return ret;
	}

	//public static void ResizeBoxCollider(this BoxCollider boxCollider, UIWidget widget)
	//{
	//	if (widget != null)
	//	{
	//		boxCollider.size = new Vector3(widget.width, widget.height, 0);
	//	}
	//}

	public static void Identity(this Transform trans)
	{
		trans.localScale = Vector3.one;
		trans.localPosition = Vector3.zero;
		trans.localRotation = Quaternion.identity;
	}

	/// <summary>
	/// .net4.0 stringbuild 会有Clear 函数，到时可以删掉这个函数
	/// </summary>
	/// <param name="sb"></param>
	public static void Clear(this StringBuilder sb)
	{
		sb.Length = 0;
	}

	/// <summary>
	///  重置transform的localPosition,localEulerAngles为0,localScale为1
	/// </summary>
	/// <param name="trans"></param>
	public static void ResetTransformLocal(this Transform trans)
	{
		trans.localPosition = Vector3.zero;
		trans.localScale = Vector3.one;
		trans.localEulerAngles = Vector3.zero;
	}

	public static void DestroyChildren(this Transform trans)
	{
		foreach (Transform child in trans)
		{
			GameObject.Destroy(child.gameObject);
		}
	}

	public static Transform AddChildFromPrefab(this Transform trans, Transform prefab, string name = null)
	{
		if (prefab == null)
		{
			Debug.LogException(new Exception("prefab is null"));
			return null;
		}
		Transform childTrans = GameObject.Instantiate(prefab) as Transform;
		childTrans.SetParent(trans, false);
		childTrans.ResetTransformLocal();
		if (!string.IsNullOrEmpty(name))
		{
			childTrans.gameObject.name = name;
		}
		return childTrans;
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
	
	 /// <summary>
    /// 获取所有的组件，不包括本身
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="trans"></param>
    /// <param name="includeInactive"></param>
    /// <returns></returns>
    public static T[] GetComponentsInChildExceptSelf<T>(this Transform trans, [System.ComponentModel.DefaultValue("true")] bool includeInactive = true) where T:Component
    {
        var components = trans.GetComponentsInChildren(typeof(T), includeInactive);
        var max = components.Length;
        List<T> newList=new List<T>();
        for (int idx = 0; idx < max; idx++)
        {
            if(components[idx].transform == trans)
                continue;
            newList.Add(components[idx] as T);
        }
        return newList.ToArray();
    }

    /// <summary>
    /// 获取所有的组件，不包括本身
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <param name="includeInactive"></param>
    /// <returns></returns>
    public static T[] GetComponentsInChildExceptSelf<T>(this GameObject obj, [System.ComponentModel.DefaultValue("true")] bool includeInactive = true) where T : Component
    {
        var components = obj.GetComponentsInChildren(typeof(T), includeInactive);
        var max = components.Length;
        List<T> newList = new List<T>();
        for (int idx = 0; idx < max; idx++)
        {
            if (components[idx].gameObject == obj)
                continue;
            newList.Add(components[idx] as T);
        }
        return newList.ToArray();
    }
	
	public static List<Transform> GetChildsByName(this Transform parent, string includeName)
	{
		if (parent == null) return null;
		var childCount = parent.childCount;
		List<Transform> childs = new List<Transform>();
		for (int idx = 0; idx < childCount; idx++)
		{
			var child = parent.GetChild(idx);
			if (child != null && child.name.Contains(includeName))
			{
				childs.Add(child);
			}
		}
		return childs;
	}
}