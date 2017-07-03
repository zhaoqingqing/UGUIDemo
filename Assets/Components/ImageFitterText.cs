using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if  UNITY_EDITOR
using UnityEditor;

#endif

/// <summary>
/// Image根据Text的大小自动调整大小
/// by qingqing-zhao 569032731@qq.com
/// </summary>
[System.Serializable]
public class ImageFitterText : MonoBehaviour
{
    [Tooltip("目标Image，如果为空则从挂载Gameobject上查找Image组件")]
    public Image image;
    private RectTransform imageRectTrans;
    [Tooltip("根据Text的长度自动调整Image的宽度")]
    public Text targetText;
    private Vector2 textScale;
    [Tooltip("上一次Text的size")]
    protected Vector2 lastTextSize;
    [Tooltip("左右宽度，上下宽度")]
    public Vector2 sizeOffset = new Vector2(16, 4);
    [Tooltip("对Text使用建议的设置，比如设置TextAlign")]
    public bool useSuggestTextSetting = true;
    [Tooltip("计算时加入Text的Scale")]
    public bool useTextScale = true;

    // Use this for initialization
    void Start()
    {
        if (image == null)
        {
            image = transform.GetComponent<Image>();
        }
        if (image != null)
        {
            imageRectTrans = image.GetComponent<RectTransform>();
        }
        if (targetText == null)
        {
            targetText = transform.GetComponentInChildren<Text>();
        }
        if (targetText != null)
        {
            textScale = targetText.GetComponent<RectTransform>().localScale.ToVector2XY();
            lastTextSize = new Vector2(targetText.preferredWidth, targetText.preferredHeight);

            if (useSuggestTextSetting)
            {
                targetText.alignment = TextAnchor.MiddleCenter;
                targetText.horizontalOverflow = HorizontalWrapMode.Overflow;
                targetText.verticalOverflow = VerticalWrapMode.Overflow;
            }
            Refresh();
        }

        if (image == null || targetText == null)
        {
            Debug.LogErrorFormat("请检查，目标Text是否为null：{0},目标Image是否为null:{1}", targetText, image);
        }
    }

    /// <summary>
    /// 获取Text的实际size，计算结果含rectTransform的scale
    /// </summary>
    /// <returns></returns>
    Vector2 GetTextPreferredSize()
    {
        if (targetText == null) return Vector2.zero;
        var size = new Vector2(targetText.preferredWidth, targetText.preferredHeight);
        if (useTextScale)
        {
            size = new Vector2(size.x * textScale.x, size.y * textScale.y);
        }
        return size;
    }

    void UpdateImageSize(Vector2 size, Vector2 offset)
    {
        if (imageRectTrans != null)
        {
            imageRectTrans.sizeDelta = size + offset;
        }
    }

    public void Refresh()
    {
        UpdateImageSize(GetTextPreferredSize(), sizeOffset * 2);
        lastTextSize = GetTextPreferredSize();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetText != null && imageRectTrans != null)
        {
            if (lastTextSize != GetTextPreferredSize())
            {
                Refresh();
            }
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(ImageFitterText))]
[CanEditMultipleObjects]
public class ImageFitterTextEditor : Editor
{
    public ImageFitterText obj;
    public override void OnInspectorGUI()
    {
        obj = target as ImageFitterText;
        base.OnInspectorGUI();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Execute"))
        {
            obj.Refresh();
        }
        EditorGUILayout.EndHorizontal();
    }
}
#endif