using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyEditorWindow : EditorWindow
{
    [MenuItem("MyTool/MyEditorWindow %g")] // ¥‹√‡≈∞ ctrl + g
    static void Open()
    {
        var window = GetWindow<MyEditorWindow>();
        window.titleContent = new GUIContent("MyTool");
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Label");
        EditorGUILayout.TextField("ABC");
        GUILayout.Button("DEF");
    }
}
