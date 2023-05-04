using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GUIContentAndStyle : EditorWindow
{
    [MenuItem("MyTool/GUIContentAndStyle")]
    static void Open()
    {
        var window = GetWindow<GUIContentAndStyle>();
        window.titleContent = new GUIContent("GUIContentAndStyle");
    }

    // GUIContent : 무엇을 그릴지. GUIStyle : 어떻게 그릴지
    private void OnGUI()
    {
        #region ====::GUIContent::====
        var myContent = new GUIContent();

        myContent.text = "textContent";
        myContent.image = EditorGUIUtility.FindTexture("BuildSettings.Editor");

        EditorGUILayout.LabelField(myContent);

        myContent.tooltip = "my tool tip";

        GUILayout.Button(myContent);
        #endregion

        #region ====::GUIStyle::====
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 15;
            style.fontStyle = FontStyle.BoldAndItalic;
            style.normal.textColor = Color.green;

            GUILayout.Label("Holy", style);
        }

        {
            GUIStyle style = new GUIStyle("button");
            style.fontSize = 15;
            style.normal.textColor = Color.red;
            style.hover = new GUIStyleState() { textColor = Color.green };

            GUILayout.Label("MyButton", style);
        }

        {
            // EditorStlyes, EditorGUIUtility, GUI.color, GUI.skin는
            // shared instance, Unityengine 내부에서도 사용하고 있는 객체들
            // var tagetStyle = EditorStyles.label;
            // 이렇게 하면 모든 label의 폰트 사이즈가 15로 바뀜
            // tagetStyle.fontSize = 30;
            // 그렇기 때문에 복사해서 사용
            var targetStyle = new GUIStyle(EditorStyles.label);
            targetStyle.fontSize = 30;

            GUILayout.Label("This is Bold Label", EditorStyles.boldLabel);
            GUILayout.Box("box", GUI.skin.window);
            
            if(GUILayout.Button("ImButton", GUI.skin.textArea))
            {
                Debug.Log("clicked");
            }
        }
        #endregion
    }

}
