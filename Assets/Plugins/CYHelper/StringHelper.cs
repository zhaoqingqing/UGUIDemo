using System.Text;
using System.Text.RegularExpressions;

internal class StringHelper
{
	private static Regex RegexBr = new Regex(@"(\r\n)", RegexOptions.IgnoreCase);

	public static Regex RegexFont = new Regex(@"<font color=" + "\".*?\"" + @">([\s\S]+?)</font>", GetRegexCompiledOptions());

	/// <summary>
	/// 得到正则编译参数设置
	/// </summary>
	/// <returns></returns>
	public static RegexOptions GetRegexCompiledOptions()
	{
		return RegexOptions.None;
	}
	/// <summary>
	/// 返回字符串真实长度, 1个汉字长度为2
	/// </summary>
	/// <returns></returns>
	public static int GetStringLength(string str)
	{
		return Encoding.Default.GetBytes(str).Length;
	}

	/// <summary>
	/// 判断指定字符串在指定字符串数组中的位置
	/// </summary>
	/// <param name="strSearch">字符串</param>
	/// <param name="stringArray">字符串数组</param>
	/// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
	/// <returns>字符串在指定字符串数组中的位置, 如不存在则返回-1</returns>
	public static int GetInArrayID(string strSearch, string[] stringArray, bool caseInsensetive)
	{
		for (int i = 0; i < stringArray.Length; i++)
		{
			if (caseInsensetive)
			{
				if (strSearch.ToLower() == stringArray[i].ToLower())
				{
					return i;
				}
			}
			else
			{
				if (strSearch == stringArray[i])
				{
					return i;
				}
			}

		}
		return -1;
	}

	/// <summary>
	/// 判断指定字符串在指定字符串数组中的位置
	/// </summary>
	/// <param name="strSearch">字符串</param>
	/// <param name="stringArray">字符串数组</param>
	/// <returns>字符串在指定字符串数组中的位置, 如不存在则返回-1</returns>		
	public static int GetInArrayID(string strSearch, string[] stringArray)
	{
		return GetInArrayID(strSearch, stringArray, true);
	}

	/// <summary>
	/// 判断指定字符串是否属于指定字符串数组中的一个元素
	/// </summary>
	/// <param name="strSearch">字符串</param>
	/// <param name="stringArray">字符串数组</param>
	/// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
	/// <returns>判断结果</returns>
	public static bool InArray(string strSearch, string[] stringArray, bool caseInsensetive)
	{
		return GetInArrayID(strSearch, stringArray, caseInsensetive) >= 0;
	}

	/// <summary>
	/// 判断指定字符串是否属于指定字符串数组中的一个元素
	/// </summary>
	/// <param name="str">字符串</param>
	/// <param name="stringarray">字符串数组</param>
	/// <returns>判断结果</returns>
	public static bool InArray(string str, string[] stringarray)
	{
		return InArray(str, stringarray, false);
	}

	/// <summary>
	/// 判断指定字符串是否属于指定字符串数组中的一个元素
	/// </summary>
	/// <param name="str">字符串</param>
	/// <param name="stringarray">内部以逗号分割单词的字符串</param>
	/// <returns>判断结果</returns>
	public static bool InArray(string str, string stringarray)
	{
		return InArray(str, SplitString(stringarray, ","), false);
	}


	/// <summary>
	/// 判断指定字符串是否属于指定字符串数组中的一个元素
	/// </summary>
	/// <param name="str">字符串</param>
	/// <param name="stringarray">内部以逗号分割单词的字符串</param>
	/// <param name="strsplit">分割字符串</param>
	/// <returns>判断结果</returns>
	public static bool InArray(string str, string stringarray, string strsplit)
	{
		return InArray(str, SplitString(stringarray, strsplit), false);
	}


	/// <summary>
	/// 判断指定字符串是否属于指定字符串数组中的一个元素
	/// </summary>
	/// <param name="str">字符串</param>
	/// <param name="stringarray">内部以逗号分割单词的字符串</param>
	/// <param name="strsplit">分割字符串</param>
	/// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
	/// <returns>判断结果</returns>
	public static bool InArray(string str, string stringarray, string strsplit, bool caseInsensetive)
	{
		return InArray(str, SplitString(stringarray, strsplit), caseInsensetive);
	}


	/// <summary>
	/// 分割字符串
	/// </summary>
	public static string[] SplitString(string strContent, string strSplit)
	{
		if (strContent.IndexOf(strSplit) < 0)
		{
			string[] tmp = { strContent };
			return tmp;
		}
		return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
	}

	/// <summary>
	/// 分割字符串
	/// </summary>
	/// <returns></returns>
	public static string[] SplitString(string strContent, string strSplit, int p_3)
	{
		string[] result = new string[p_3];

		string[] splited = SplitString(strContent, strSplit);

		for (int i = 0; i < p_3; i++)
		{
			if (i < splited.Length)
				result[i] = splited[i];
			else
				result[i] = string.Empty;
		}

		return result;
	}

	/// <summary>
	/// 删除字符串尾部的回车/换行/空格
	/// </summary>
	/// <param name="str"></param>
	/// <returns></returns>
	public static string RTrim(string str)
	{
		for (int i = str.Length; i >= 0; i--)
		{
			if (str[i].Equals(" ") || str[i].Equals("\r") || str[i].Equals("\n"))
			{
				str.Remove(i, 1);
			}
		}
		return str;
	}

	/// <summary>
	/// 清除给定字符串中的回车及换行符
	/// </summary>
	/// <param name="str">要清除的字符串</param>
	/// <returns>清除后返回的字符串</returns>
	public static string ClearBR(string str)
	{
		//Regex r = null;
		Match m = null;

		//r = new Regex(@"(\r\n)",RegexOptions.IgnoreCase);
		for (m = RegexBr.Match(str); m.Success; m = m.NextMatch())
		{
			str = str.Replace(m.Groups[0].ToString(), "");
		}


		return str;
	}

	/// <summary>
	/// 从字符串的指定位置截取指定长度的子字符串
	/// </summary>
	/// <param name="str">原字符串</param>
	/// <param name="startIndex">子字符串的起始位置</param>
	/// <param name="length">子字符串的长度</param>
	/// <returns>子字符串</returns>
	public static string CutString(string str, int startIndex, int length)
	{
		if (startIndex >= 0)
		{
			if (length < 0)
			{
				length = length * -1;
				if (startIndex - length < 0)
				{
					length = startIndex;
					startIndex = 0;
				}
				else
				{
					startIndex = startIndex - length;
				}
			}


			if (startIndex > str.Length)
			{
				return "";
			}


		}
		else
		{
			if (length < 0)
			{
				return "";
			}
			else
			{
				if (length + startIndex > 0)
				{
					length = length + startIndex;
					startIndex = 0;
				}
				else
				{
					return "";
				}
			}
		}

		if (str.Length - startIndex < length)
		{
			length = str.Length - startIndex;
		}

		return str.Substring(startIndex, length);
	}


	/// <summary>
	/// 从字符串的指定位置开始截取到字符串结尾的了符串
	/// </summary>
	/// <param name="str">原字符串</param>
	/// <param name="startIndex">子字符串的起始位置</param>
	/// <returns>子字符串</returns>
	public static string CutString(string str, int startIndex)
	{
		return CutString(str, startIndex, str.Length);
	}


	/// <summary>
	/// 是否为ip
	/// </summary>
	/// <param name="ip"></param>
	/// <returns></returns>
	public static bool IsIP(string ip)
	{
		return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");

	}
}