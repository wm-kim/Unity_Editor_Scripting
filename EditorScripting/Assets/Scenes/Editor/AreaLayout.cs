using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class AreaLayout : EditorWindow
{
    Vector3 scrollPos;
    Vector3 scrollPos2;

    [MenuItem("MyTool/Area")]
    static void Open()
    {
        var window = GetWindow<AreaLayout>();
        window.titleContent = new GUIContent("Area");
    }

    private void OnGUI()
    {
#if false
        #region ====::Area::====
        var offset = new Vector2(20, 40);
        var rtArea = new Rect(offset.x, offset.y, position.width - offset.x * 2, 200);

        GUILayout.BeginArea(rtArea, GUI.skin.window);
        {
            #region ====::Mutliple Area::====

            var rtSub = rtArea;
            rtSub.Set(0, 0, rtSub.width * 0.5f, rtSub.height);

            // Left
            GUILayout.BeginArea(rtSub, "Sub01", GUI.skin.window);
            {
                scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
                {
                    EditorGUILayout.BeginVertical();
                    {
                        for(int i =0; i < 30; i++)
                        {
                            EditorGUILayout.LabelField("HeleHoly");
                        }
                    }
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndScrollView();
            }
            GUILayout.EndArea();

            // Right
            rtSub.x += rtSub.width;
            GUILayout.BeginArea(rtSub, "Sub02", GUI.skin.window);
            {
                scrollPos2 = EditorGUILayout.BeginScrollView(scrollPos2);
                {
                    EditorGUILayout.BeginHorizontal();
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            EditorGUILayout.LabelField("HeleHoly");
                        }
                    }
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndScrollView();
            }
            GUILayout.EndArea();
            #endregion
        }
        GUILayout.EndArea();
        #endregion
#endif

        #region ====::Scope::====
        #region ====::Horizontal::====

        // 해당 UI 안에서 그려지는 모든 GUI들은
        // 전부다 begin horizontal과 end horizontal 사이에 그려지는 것과 같다.
        using (var scope = new EditorGUILayout.HorizontalScope())
        {
            // rect안에는 scope 안에 그렸던 모든 GUI들을 합친 크기가 들어간다.
            // GUIContent.none : 아무것도 없는 빈 공간을 의미한다.
            if (GUI.Button(scope.rect, GUIContent.none))
            {
                Debug.Log("clicked");
            }
            
            for (int i = 0; i < 5; i++)
            {
                GUILayout.Label("Label");
                GUILayout.Box(EditorGUIUtility.FindTexture("BuildSettings.Editor"));
            }
        }
        #endregion

        #region ====::Vertical::====

        using (var scope = new EditorGUILayout.VerticalScope(GUILayout.Width(100)))
        {
            if (GUI.Button(scope.rect, GUIContent.none))
            {
                Debug.Log("clicked");
            }

            for (int i = 0; i < 5; i++)
            {
                GUILayout.Label("Label");
                GUILayout.Box(EditorGUIUtility.FindTexture("BuildSettings.Editor"));
            }
        }

        #endregion
        #endregion
    }
}
