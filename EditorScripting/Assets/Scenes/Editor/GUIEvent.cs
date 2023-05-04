using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEditor;
using UnityEngine;

public class GUIEvent : EditorWindow
{
    [MenuItem("MyTool/GUIEvent")]
    static void Open()
    {
        var window = GetWindow<GUIEvent>();
        window.titleContent = new GUIContent("GUIEvent");
    }

    /*
    GUI drawing 코드들은 전부 이 함수 안에서 작성해야 한다.
    OnGUI를 호출하는 것은 low level인 event에서 호출한다.
    OnGUI 내부 코드와 현재 Event 관계 여부에 따라 무시될 수 있다.
    drawing 관련 코드가 있어도 현재 event가 drawing이 아니면 무시된다.

    Layout event : drawing (repaint) 전 GUI 들의 배치 값 관련 수집 이벤트
    Layout event와 repaint event 사이에 GUI drawing에 관련된 값 변경이 있으면 에러가 발생
    */

    private void OnGUI()
    {
        Debug.Log(Event.current.type.ToString());
        // layout에서 크기를 조사 했기 때문에 repaint 때 값이 들어가게 됨.
        var area = EditorGUILayout.BeginVertical(GUILayout.Width(200));

        GUI.Box(area, GUIContent.none);

        EditorGUILayout.LabelField("Hello World");
        EditorGUILayout.LabelField("Hello World");

        EditorGUILayout.EndVertical();

        #region ====::Event::====
        // get key 'A' event
        if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.A)
        {
            Debug.Log("A key has been pressed");
        }

        // get mouse left button event
        if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
        {
            Debug.Log("Mouse left button has been pressed");
        }

        if(Event.current.isMouse)
        {
            // Button 함수는 내부적으로 Mouse Event일 때만 동작하기 때문에 
            // event가 제거되면 동작하지 않는다.
            Event.current.Use();
        }

        // 마우스를 클릭한 해당 위치에 버튼이 있을 때 버튼까지 같이 눌림
        if (GUILayout.Button("Click Me"))
        {
            Debug.Log("How did you click me ??? ");
        }

        #endregion
    }
}
