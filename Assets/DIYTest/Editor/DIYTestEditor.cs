using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DIYTest), true)]
public class DIYTestEditor : Editor {

    public override void OnInspectorGUI()
    {
        //DIYTest diy = target as DIYTest;
        //serializedObject.Update();
        base.OnInspectorGUI();
    }
}
