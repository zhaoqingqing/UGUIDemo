
public class NumberHelper
{
	/// <summary>
	/// 人性化数字显示，百万，千万，亿
	/// </summary>
	/// <param name="number"></param>
	/// <returns></returns>
	public static string HumanizeNumber(int number)
	{
		if (number > 100000000)
		{
			return string.Format("{0}{1}", number / 100000000, "亿");
		}
		else if (number > 10000000)
		{
			return string.Format("{0}{1}", number / 10000000, "千万");
		}
		else if (number > 1000000)
		{
			return string.Format("{0}{1}", number / 1000000, "百万");
		}
		else if (number > 10000)
		{
			return string.Format("{0}{1}", number / 10000, "万");
		}

		return number.ToString();
	}

    /// <summary>
    /// 数字格式化显示，不足位数补0
    /// </summary>
    /// <param name="number"></param>
    /// <param name="maxLength">位数</param>
    /// <returns></returns>
    public static string FormatFillZero(int number, int maxLength)
    {
        if (number.ToString().Length < maxLength)
        {
            var count = maxLength - number.ToString().Length;
            string zeroStr = null;
            for (int idx = 0; idx < count; idx++)
            {
                zeroStr = string.Concat("0", zeroStr);
            }
            return string.Concat(zeroStr, number);
        }
        return number.ToString();
    }
}