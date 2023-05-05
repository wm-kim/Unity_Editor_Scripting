using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

// 타 Editor Insepector GUI를 원하는 곳에 그리기
public class CopyEditorWindow : EditorWindow
{
    Editor duplicatedEditor;
    Editor[] duplicatedDetailEditor;
    List<bool> detailFoldOut = new List<bool>();
    
    [MenuItem("MyTool/CopyEditorWindow")]
    static void Open()
    {
        var window = GetWindow<CopyEditorWindow>();
        window.titleContent = new GUIContent("CopyEditorWindow");
    }

    private void OnGUI()
    {
        if (Selection.objects != null && Selection.objects.Length == 1)
        {
            var target = Selection.objects[0];
            if (duplicatedEditor == null || duplicatedEditor.name != target.name)
            {
                duplicatedEditor = Editor.CreateEditor(target);

                // 선택한 것을 GameObject로 변환에 성공한다면
                var go = target as GameObject;
                if (go != null)
                {
                    var allComps = go.GetComponents(typeof(Component));
                    if (allComps != null)
                    {
                        duplicatedDetailEditor = new Editor[allComps.Length];
                        for (int i = 0; i < allComps.Length; i++)
                        {
                            detailFoldOut.Add(false);
                            duplicatedDetailEditor[i] = Editor.CreateEditor(allComps[i]);
                        }
                    }
                }
                else
                {
                    detailFoldOut.Clear();
                    duplicatedDetailEditor = null;
                }
            }
        }
        else
        {
            duplicatedEditor = null;
        }

        if (duplicatedEditor != null)
        {
            duplicatedEditor.DrawHeader();
            duplicatedEditor.OnInspectorGUI();

            if(duplicatedDetailEditor != null)
            {
                for(int i = 0; i < duplicatedDetailEditor.Length; i++)
                {
                    detailFoldOut[i] = EditorGUILayout.Foldout(detailFoldOut[i], $"{duplicatedDetailEditor[i].target.GetType()}");
                    
                    if(detailFoldOut[i])
                    {
                        duplicatedDetailEditor[i].OnInspectorGUI();
                    }
                }
            }
        }
    }
}
