using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Detail		:  Desc
/// Author		:  qingqing-zhao(569032731@qq.com)
/// CreateTime  :  #CreateTime#
/// </summary>
public class LayoutTest : MonoBehaviour
{
    public int HideCount = 3;
    public VerticalLayoutGroup VLayoutGroup;
    public GameObject Prefab;

    [ContextMenu("Hide")]
    void Hide()
    {
        DoAction(false);
    }

    [ContextMenu("Show")]
    void Show()
    {
        DoAction(true);
    }

    void DoAction(bool active)
    {
        var max = transform.childCount;
        if (HideCount >= max)
        {
            HideCount = max - 1;
        }
        for (int idx = HideCount; idx < max; idx++)
        {
            var child = transform.GetChild(idx);
            child.GetComponent<LayoutElement>().ignoreLayout = !active;
            child.gameObject.SetActive(active);
        }
    }

    [ContextMenu("生成5")]
    void Spawn1()
    {
        Spawn(5);
    }
    [ContextMenu("生成2")]
    void Spawn2()
    {
        Spawn(2);
    }

    void Spawn(int count)
    {
        if (transform.childCount > 0)
        {
            //TODO 删除
            UnityHelper.DestoryAllChild(transform);
        }

        for (int idx = 0; idx < count; idx++)
        {
            var clone = GameObject.Instantiate(Prefab) as GameObject;
            clone.transform.SetParent(transform);

            clone.transform.SetLocalPositionZ(0);
            clone.transform.SetLocalScale(Vector3.one);
        }
        //VLayoutGroup.SetLayoutVertical();
        VLayoutGroup.CalculateLayoutInputVertical();
    }

    void Start()
    {
        VLayoutGroup = gameObject.GetComponent<VerticalLayoutGroup>();
        if (VLayoutGroup)
        {
            //不要强制修改child的Height
            VLayoutGroup.childForceExpandHeight = false;
        }

    }

    public void OnEnable()
    {
        Spawn(2);
    }
}
