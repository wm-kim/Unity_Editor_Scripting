using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LayoutTest : EditorWindow
{
    [MenuItem("MyTool/LayoutTest")] 
    static void Open()
    {
        var window = GetWindow<LayoutTest>();
        window.titleContent = new GUIContent("LayoutTest");
    }

    private void OnGUI()
    {
        #region ====::Layout을 좀 더 정밀하게 다루어보자::====

        #region ====::Vertical::====

        EditorGUILayout.BeginVertical();
        {
            for (int i = 0; i < 3; i++)
            {
                EditorGUILayout.LabelField("Label01");
            }
        }
        EditorGUILayout.EndVertical();

        EditorGUILayout.Space(5);

        #endregion

        #region ====::Horizontal::====
        EditorGUILayout.BeginHorizontal();
        {
            for (int i = 0; i < 10; i++)
            {
                EditorGUILayout.LabelField("FieldLabel");
            }
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        {
            for (int i = 0; i < 10; i++)
            {
                EditorGUILayout.LabelField("FieldLabel");
            }
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        #region ====::Horizon && Vertical::====
        #endregion
        for (int i = 0; i < 5; i++)
        {
            EditorGUILayout.BeginVertical();
            {
                EditorGUILayout.LabelField($"Title : {i}");

                var backUp01 = EditorGUIUtility.fieldWidth;
                var backUp02 = EditorGUIUtility.labelWidth;

                EditorGUIUtility.fieldWidth = 50;
                EditorGUIUtility.labelWidth = 50;

                EditorGUILayout.BeginHorizontal();
                {
                    for (int j = 0; j < 3; j++)
                    {
                        EditorGUILayout.TextField(j.ToString(), "put data here");

                        bool isLastData = j == 2;
                        if (isLastData == false)
                        {
                            EditorGUILayout.Space(6);
                        }
                    }
                }
                EditorGUILayout.EndHorizontal();

                EditorGUIUtility.fieldWidth = backUp01;
                EditorGUIUtility.labelWidth = backUp02;
            }
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(10);
            
            if(i < 4)
            {
                EditorGUILayout.LabelField("", GUI.skin.horizontalScrollbar);
            }
        }
        #endregion

        #region ====::Area::====

        var offset = new Vector2(20, 40);
        var rtArea = new Rect(offset.x, offset.y, position.width - offset.x * 2, 200);

        GUILayout.BeginArea(rtArea, GUI.skin.window);
        {
            EditorGUILayout.LabelField("Area");
        }
        GUILayout.EndArea();
        #endregion
    }
}
