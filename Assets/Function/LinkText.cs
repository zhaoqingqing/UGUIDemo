using UnityEngine;
using System.Collections;
using System.ComponentModel;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
[CustomEditor(typeof(LinkText))]
public class LinkTextEditor : Editor
{
    public LinkText MLinkText;

    public void OnEnable()
    {
        MLinkText = target as LinkText;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("生成下划线"))
        {
            MLinkText.CreateLink();
        }
    }
}
#endif

/// <summary>
/// 给Text增加下划线
/// </summary>
[RequireComponent(typeof(Text))]
public class LinkText : MonoBehaviour
{
    public float offsetTop = 10;

    [ReadOnly(true)]
    public string childName = "Underline";

    void Awake()
    {
        CreateLink();
    }

    public void CreateLink()
    {
        Text text = gameObject.GetComponent<Text>();
        
        //        if (transform.childCount > 0)
        //        {
        //            for (int idx = 0; idx < transform.childCount; idx++)
        //            {
        //                var child = transform.GetChild(idx);

        //#if UNITY_EDITOR
        //                DestroyImmediate(child.gameObject);
        //#else
        //                Destroy(child.gameObject);
        //#endif
        //            }
        //        }
        var lastSpawn = transform.FindChild(childName);
        if (lastSpawn)
        {
#if UNITY_EDITOR
            DestroyImmediate(lastSpawn.gameObject);
#else
                            Destroy(lastSpawn.gameObject);
#endif
        }
        //克隆Text，获得相同的属性
        Text underline = Instantiate(text) as Text;
        //删除自己这个组件
        DestroyImmediate(underline.GetComponent<LinkText>());
        underline.name = childName;

        underline.transform.SetParent(text.transform);
        underline.transform.localScale = Vector3.one;
        RectTransform rt = underline.rectTransform;

        //设置下划线坐标和位置
        rt.anchoredPosition3D = Vector3.zero;
        rt.offsetMax = new Vector2(0, -offsetTop);
        rt.offsetMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.anchorMin = Vector2.zero;

        underline.text = "_";
        float perlineWidth = underline.preferredWidth;      //单个下划线宽度
        Debug.Log(perlineWidth);

        float width = text.preferredWidth;
        Debug.Log(width);
        int lineCount = (int)Mathf.Round(width / perlineWidth);
        Debug.Log(lineCount);
        for (int i = 1; i < lineCount; i++)
        {
            underline.text += "_";
        }
    }
}