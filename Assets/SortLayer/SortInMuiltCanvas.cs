using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 只有多个canvas的排序
/// 如果设置Canvas的Sort Order属性,只能设置int值
/// </summary>
public class SortInMuiltCanvas : MonoBehaviour
{
    public Button BtnSort;
    public Canvas CanvasWhite;
    public Canvas CanvasRed;
    public Canvas CanvasBlue;

    //http://blog.csdn.net/akailee/article/details/51798288 会增加Canvas
    //http://forum.china.unity3d.com/thread-1572-1-1.html 修改SortLayer

    // Use this for initialization
    void Start()
    {
        BtnSort.onClick.AddListener(OnSort);
    }

    void OnSort()
    {
        CanvasBlue.sortingOrder = -1;
    }
}
