using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// 扩展Unity的方法
/// </summary>
public static class UnityEx
{
	public static Vector2 ToVector2XY(this Vector3 vec)
	{
		return new Vector2(vec.x, vec.y);
	}

    public static Vector2 ToVector2XZ(this Vector3 vec)
    {
        return new Vector2(vec.x, vec.z);
    }

	public static bool HasRigidbody_(this GameObject gobj)
	{
		return (gobj.GetComponent<Rigidbody>() != null);
	}

	public static bool HasAnimation_(this GameObject gobj)
	{
		return (gobj.GetComponent<Animation>() != null);
	}

	public static void SetSpeed_(this Animation anim, float newSpeed)
	{
		anim[anim.clip.name].speed = newSpeed;
	}

	

	/// <summary>
	///  重置transform的localPosition,localEulerAngles为0,localScale为1
	/// </summary>
	/// <param name="trans"></param>
	public static void ResetLocal(this Transform trans)
	{
		trans.localPosition = Vector3.zero;
		trans.localScale = Vector3.one;
		trans.localEulerAngles = Vector3.zero;
	}

    public static void IdentityLocal(this Transform trans)
    {
        trans.localScale = Vector3.one;
        trans.localPosition = Vector3.zero;
        trans.localRotation = Quaternion.identity;
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
		childTrans.ResetLocal();
		if (!string.IsNullOrEmpty(name))
		{
			childTrans.gameObject.name = name;
		}
		return childTrans;
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

    /// <summary>
    /// 获取所有的Child，当你需要对Child进行数量上的更改时(eg:setParent)，使用这个方法
    /// </summary>
    /// <param name="tr"></param>
    /// <returns></returns>
    public static IEnumerable<Transform> GetChildren(this Transform tr)
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in tr)
        {
            children.Add(child);
        }
        // You can make the return type an array or a list or else.
        return children as IEnumerable<Transform>;
    }
}