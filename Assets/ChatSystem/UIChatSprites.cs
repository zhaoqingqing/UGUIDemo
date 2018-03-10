using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class UIChatSprites : MonoBehaviour
{
    [SerializeField]
    public List<Sprite> AllsSprites;

    public Dictionary<string, Sprite> font;

    void Awake()
    {
        Init();

    }

    // Use this for initialization
    void Start()
    {
        Init();
    }

    public void Init()
    {
        if (font != null)
        {
            return;
        }
        font = new Dictionary<string, Sprite>();
        for (int i = 0; i < AllsSprites.Count; i++)
        {
            if (!font.ContainsKey(AllsSprites[i].name))
            {
                font.Add(AllsSprites[i].name, AllsSprites[i]);
            }
        }
    }

    public Sprite GetSprite(string key)
    {
        Init();
        Sprite sprite = null;
        if (font != null)
        {
            font.TryGetValue(key, out sprite);
        }
        return sprite;
    }
}



#if UNITY_EDITOR
[CustomEditor(typeof(UIChatSprites))]
public class UIChatSpritesEditor : Editor
{
    public UIChatSprites obj;
    public override void OnInspectorGUI()
    {
        obj = target as UIChatSprites;
        base.OnInspectorGUI();
        GUILayout.Label("使用说明");
        GUILayout.Label("1.拖放全部的Sprite到Sprites");
        GUILayout.Label("2.点击自动填充Key");
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("自动填充Key"))
        {
            obj.Init();
        }
        if (GUILayout.Button("清空所有Key"))
        {
            obj.font.Clear();
        }

        EditorGUILayout.EndHorizontal();
    }
}
#endif