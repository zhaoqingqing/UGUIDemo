using System;
using System.Text;


public class DatetimeHelper
{
	public static DateTime GetDateTime(double unixTimeStamp)
	{
		DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		return origin.AddSeconds(unixTimeStamp);
	}


	// 同Lua, Lib:GetUtcDay
	public static int GetUtcDay()
	{
		DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		DateTime now = DateTime.UtcNow;
		var span = now - origin;

		return span.Days;
	}

	public static int GetDeltaMinutes(DateTime origin)
	{
		DateTime now = DateTime.UtcNow;
		var span = now - origin;

		return span.Minutes;
	}

	public static int GetDeltaHours(DateTime origin)
	{
		DateTime now = DateTime.UtcNow;
		var span = now - origin;

		return span.Hours;
	}

	public static int GetDeltaDay(DateTime origin)
	{
		DateTime now = DateTime.UtcNow;
		var span = now - origin;

		return span.Days;
	}

	/// <summary>
	/// Utc毫秒转Utc时间
	/// </summary>
	/// <param name="utcTime"></param>
	/// <param name="zone">默认0时区</param>
	/// <returns></returns>
	public static DateTime GetDateTimeByUtcMilliseconds(long utcTime, int zone = 0)
	{
		DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		return origin.AddMilliseconds(utcTime).AddHours(zone);
	}
	/// <summary>
	/// Utc秒转Utc时间
	/// </summary>
	/// <param name="unixTimeStamp"></param>
	/// <param name="zone">默认0时区</param>
	/// <returns></returns>
	public static DateTime GetDateTimeByUtcSeconds(double unixTimeStamp, int zone = 0)
	{
		DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		return origin.AddSeconds(unixTimeStamp).AddHours(zone);
	}
	/// <summary>
	/// Unix時間總毫秒數
	/// </summary>
	/// <returns></returns>
	public static double GetUtcMilliseconds()
	{
		return GetUtcMilliseconds(DateTime.UtcNow);
	}
	/// <summary>
	/// Unix時間總毫秒數
	/// </summary>
	/// <returns></returns>
	public static double GetUtcMilliseconds(DateTime date)
	{
		DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		TimeSpan diff = date - origin;
		return diff.TotalMilliseconds;
	}

	/// <summary>
	/// Unix時間總秒數
	/// </summary>
	/// <returns></returns>
	public static double GetUtcSeconds()
	{
		return GetUtcSeconds(DateTime.UtcNow);
	}

	/// <summary>
	/// Unix時間總秒數
	/// </summary>
	/// <returns></returns>
	public static double GetUtcSeconds(DateTime date)
	{
		DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		TimeSpan diff = date - origin;
		return diff.TotalSeconds;
	}


	public static string HumanizeTimeString(int seconds)
	{
		TimeSpan ts = TimeSpan.FromSeconds(seconds);
		StringBuilder sb = new StringBuilder();
		sb.Append(ts.Days == 0 ? "" : string.Concat(ts.Days, "天"));
		sb.Append(ts.Hours == 0 ? "" : string.Concat(ts.Hours, "小时"));
		sb.Append(ts.Minutes == 0 ? "" : string.Concat(ts.Minutes, "分钟"));
		sb.Append(ts.Seconds == 0 ? "" : string.Concat(ts.Seconds, "秒"));

		return sb.ToString();
	}

    /// <summary>
    /// 计算两个日期相隔的天数
    /// </summary>
    /// <param name="lastDate"></param>
    /// <param name="nowDate"></param>
    /// <returns></returns>
    public static int DateDiff(DateTime oldDate, DateTime newDate)
    {
        // Difference in days, hours, and minutes.
        TimeSpan ts = newDate - oldDate;

        // Difference in days.
        return ts.Days;
    }
}