using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 让ScrollRect滑动到底部
/// https://docs.unity3d.com/ScriptReference/UI.ScrollRect-verticalNormalizedPosition.html
/// </summary>
public class ScrollToBottomTest : MonoBehaviour
{
    public ScrollRect ScrollRect;
    public float siderValue = 0;
    private float lastSiderValue = 0;
    public bool enableDebug = true;

    // Use this for initialization
    void Start()
    {
        if (ScrollRect == null) ScrollRect = gameObject.GetComponent<ScrollRect>();
        lastSiderValue = siderValue;
    }


    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(80, 20, 200, 200));
        GUILayout.Label(siderValue.ToString());
        siderValue = GUILayout.HorizontalSlider(siderValue, 0, 1, GUILayout.MinWidth(200), GUILayout.MinHeight(20));

        if (ScrollRect && enableDebug && lastSiderValue != siderValue)
        {
            ScrollRect.verticalNormalizedPosition = siderValue;
            lastSiderValue = siderValue;
        }

        if (GUILayout.Button("滑动到底部", GUILayout.MinWidth(80), GUILayout.MinHeight(40)))
        {
            ScrollRect.verticalNormalizedPosition = 0;
        }

        if (GUILayout.Button("滑动到顶部", GUILayout.MinWidth(80), GUILayout.MinHeight(40)))
        {
            ScrollRect.verticalNormalizedPosition = 1;
        }
        GUILayout.EndArea();
    }
}