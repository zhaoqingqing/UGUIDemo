using System;
using UnityEngine;
using System.Collections;
using System.IO;


/// <summary>
/// 贴图辅助工具
/// </summary>
public class TextureHelper
{
    /// <summary>
    /// 以IO方式进行加载
    /// </summary>
    public static void LoadByIO(string fullFilePath, Action<Texture2D> callback, int width, int height)
    {
        if (string.IsNullOrEmpty(fullFilePath))
        {
            Debug.LogError("文件路径不能为空!");
            if (callback != null) callback(null);
            return;
        }
        double startTime = (double)Time.time;
        //创建文件读取流
        FileStream fileStream = new FileStream(fullFilePath, FileMode.Open, FileAccess.Read);
        fileStream.Seek(0, SeekOrigin.Begin);
        //创建文件长度缓冲区
        byte[] bytes = new byte[fileStream.Length];
        //读取文件
        fileStream.Read(bytes, 0, (int)fileStream.Length);
        //释放文件读取流
        fileStream.Close();
        fileStream.Dispose();
        fileStream = null;

        //创建Texture
        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(bytes);
        if (callback != null) callback(texture);
        startTime = (double)Time.time - startTime;
        Debug.LogFormat("IO加载用时:{0}" , startTime);
    }

    /// <summary>
    /// 以WWW方式进行加载
    /// </summary>
    /// <param name="fullFilePath"></param>
    /// <returns></returns>
    public static IEnumerator LoadByWWW(string fullFilePath, Action<Texture2D> callback)
    {
        double startTime = (double)Time.time;
        string loadPath = string.Empty;
#if UNITY_EDITOR_WIN
        loadPath = "file:///" + fullFilePath;
#else
        loadPath = "file://" + fullFilePath;
#endif

        //请求WWW
        WWW www = new WWW(loadPath);
        yield return www;
        if (www != null && string.IsNullOrEmpty(www.error))
        {
            //获取Texture
            Texture2D texture = www.texture;

            if (callback != null) callback(texture);
            startTime = (double)Time.time - startTime;
            Debug.LogFormat("WWW加载用时:{0}" , startTime);
        }
        else
        {
            Debug.LogErrorFormat("www 加载图片失败:{0}", www.error);
            if (callback != null) callback(null);
        }
    }

    public static Sprite Texture2Sprite(Texture2D texture)
    {
        if (texture == null) return null;
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }
}
