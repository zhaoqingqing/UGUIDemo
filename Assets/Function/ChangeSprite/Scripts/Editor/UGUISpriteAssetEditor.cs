using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UGUISpriteAsset))]
public class UGUISpriteAssetEditor : Editor
{

    UGUISpriteAsset spriteAsset;

    public void OnEnable()
    {
        spriteAsset = (UGUISpriteAsset)target;
    }
    private Vector2 ve2ScorllView;
    public override void OnInspectorGUI()
    {
        ve2ScorllView = GUILayout.BeginScrollView(ve2ScorllView);
        GUILayout.Label("UGUI Sprite Asset");
        if (spriteAsset.listSpriteAssetInfor == null)
            return;
        for (int i = 0; i < spriteAsset.listSpriteAssetInfor.Count; i++)
        {
            GUILayout.Label("\n");
            EditorGUILayout.ObjectField("", spriteAsset.listSpriteAssetInfor[i].sprite, typeof(Sprite));
            EditorGUILayout.IntField("ID:", spriteAsset.listSpriteAssetInfor[i].ID);
            EditorGUILayout.LabelField("name:", spriteAsset.listSpriteAssetInfor[i].name);
            EditorGUILayout.Vector2Field("povit:", spriteAsset.listSpriteAssetInfor[i].pivot);
            EditorGUILayout.RectField("rect:", spriteAsset.listSpriteAssetInfor[i].rect);
            GUILayout.Label("\n");
        }
        GUILayout.EndScrollView();
    }

}

