using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyEditorWindow : EditorWindow
{
    [MenuItem("MyTool/MyEditorWindow %g")] // 단축키 ctrl + g
    static void Open()
    {
        var window = GetWindow<MyEditorWindow>();
        window.titleContent = new GUIContent("MyTool");
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(250, 0, 100, 50), "GUI.Label");
        EditorGUI.LabelField(new Rect(250, 50, 100, 50), "EditorGUI.LabelField");

        // Layout의 의미는 Unity의 자동 Layout system을 사용한 GUI
        GUILayout.Label("GUILayout.Label");
        EditorGUILayout.LabelField("EditorGUILayout.LabelField");

        // GUI와 Editor GUI를 분리한 이유
        // Editor GUI는 Inspector와 같은 Editor에서만 사용 가능
        // Editor뿐 아니라 게임 내에서도 사용가능한 GUI는 GUI를 사용해야함
    }
}
