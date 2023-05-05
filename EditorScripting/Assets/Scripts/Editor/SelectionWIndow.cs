using System.Collections;
using System.Collections.Generic;
using System.Drawing.Design;
using UnityEditor;
using UnityEngine;

public class SelectionWIndow : EditorWindow
{
    string stringVar;
    int intValue;

    [MenuItem("MyTool/SelectionWIndow")]
    static void Open()
    {
        var window = GetWindow<SelectionWIndow>();
        window.titleContent = new GUIContent("SelectionWIndow");
    }

    private void OnGUI()
    {
        #region ====::Selection::====
        if (GUILayout.Button("모든 Scene Object 선택하기"))
        {
            var targets = FindObjectsOfType<GameObject>(true);
            if(targets != null)
            {
                Selection.objects = targets;
            }
        }

        if(GUILayout.Button("모든 Text 선택하기"))
        {
            var targets = FindObjectsOfType<UnityEngine.UI.Text>(true);
            if (targets != null)
            {
                GameObject[] gos = new GameObject[targets.Length];
                for (int i = 0; i < targets.Length; i++)
                {
                    gos[i] = targets[i].gameObject;
                }
                Selection.objects = gos;
            }
        }

        if(GUILayout.Button("선택한 Object 핑 찍기"))
        {
            if(Selection.objects != null && Selection.objects.Length == 1)
            {
                EditorGUIUtility.PingObject(Selection.objects[0]);
            }
        }
        #endregion

        #region ====::EditorPrefs 활용::====
        // Ram이 아닌 Disk에 저장됨
        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.PrefixLabel("String");
            stringVar = GUILayout.TextArea(stringVar);
        }
        EditorGUILayout.EndHorizontal();
        intValue = EditorGUILayout.IntField("int", intValue);

        if(GUILayout.Button("값 저장하기"))
        {
            EditorPrefs.SetString("MyStringKey", stringVar);
            EditorPrefs.SetInt("MyIntKey", intValue);
        }

        if (GUILayout.Button("값 불러오기"))
        {
            stringVar = EditorPrefs.GetString("MyStringKey");
            intValue = EditorPrefs.GetInt("MyIntKey");
        }

        if (GUILayout.Button("값 삭제하기"))
        {
            EditorPrefs.DeleteKey("MyStringKey");
            EditorPrefs.DeleteKey("MyIntKey");
        }
        #endregion
    }
}
