using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using UnityEngine;

public partial class XToolUtils
{
	/// <summary>
	/// 转换类型
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="pObj"></param>
	/// <returns></returns>
	public static T ChangeType<T>(object pObj)
	{
		try
		{
			return (T)System.Convert.ChangeType(pObj, typeof(T));
		}
		catch (Exception ex)
		{
			Debug.LogError("转换类型错误：" + ex);
			return default(T);
		}
	}

	/// <summary>
	/// 切割字符串，获取列表，比如："1,2,3"转换成List<int>{1,2,3}
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="pStr"></param>
	/// <param name="pChars"></param>
	/// <returns></returns>
	public static List<T> GetList<T>(string pStr, params char[] pChars)
	{
		List<T> _list = new List<T>();
		if (pChars != null && !string.IsNullOrEmpty(pStr) && pChars.Length > 0)
		{
			string[] _arrays = pStr.Split(pChars, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < _arrays.Length; i++)
			{
				T _temp = ChangeType<T>(_arrays[i]);
				if (_temp != null)
				{
					_list.Add(_temp);
				}
			}
		}
		if (_list.Count == 0)
		{
			Debug.LogError("列表为空！");
		}
		return _list;
	}
}