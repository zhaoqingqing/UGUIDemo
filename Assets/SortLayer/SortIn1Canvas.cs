using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 只有1个canvas的排序
/// </summary>
public class SortIn1Canvas : MonoBehaviour
{

    public Image ImageA;
    public Image ImageB;
    public Image ImageMiddle;
    public Button BtnSet;
    public int ImageMiddleSiblingIndex;
    public bool Toggle = true;

    // Use this for initialization
    void Start()
    {
        BtnSet.onClick.AddListener(SortBySiblingIndex);
        ImageMiddleSiblingIndex = ImageMiddle.transform.GetSiblingIndex();
    }


    void SortBySiblingIndex()
    {
        /*
        把图片设置在两张图的中间层
        此种方法会修改图片在hierarchy的层级！
        在RectTransform属性面板上右键点击 Move to Fornt 或 Move to Back也是调用此API
        */
        var tmpSibling = Toggle ? ImageB.transform.GetSiblingIndex() : ImageMiddleSiblingIndex;
        ImageMiddle.transform.SetSiblingIndex(tmpSibling);
        Toggle = !Toggle;
    }

    void SortByOther()
    {
        /*
       TODO 其它方法
        */

    }

}
