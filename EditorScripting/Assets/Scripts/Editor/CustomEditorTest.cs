using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CustomScript))]
public class CustomEditorTest : Editor
{
    CustomScript targetRef;

    SerializedProperty targetObjectProp;
    SerializedProperty nameProp;
    SerializedProperty hpProp;

    private void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;

        // 데이터 타입을 명시하지 않음 (Generic)
        targetObjectProp = serializedObject.FindProperty($"{nameof(CustomScript.otherObject)}");
        nameProp = serializedObject.FindProperty($"{nameof(CustomScript.myName)}");
        hpProp = serializedObject.FindProperty($"{nameof(CustomScript.myHP)}");

        targetRef = (CustomScript)base.target;
    }

    private void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();

        // 어디선가 변경된 값이 있을 수 있으므로 업데이트
        serializedObject.Update();

        if (hpProp.intValue < 500) GUI.color = Color.red;
        else GUI.color = Color.green;

        hpProp.intValue = EditorGUILayout.IntSlider("HP값", hpProp.intValue, 0, 1000);

        EditorGUILayout.BeginHorizontal();
        {
            GUI.color = Color.blue;
            EditorGUILayout.PrefixLabel("이름");
            GUI.color = Color.white;
            nameProp.stringValue = EditorGUILayout.TextArea(nameProp.stringValue);
        }
        EditorGUILayout.EndHorizontal();

        // PropertyField : 해당 Property의 실제 type에 따라 드로잉을 다르게 처리
        EditorGUILayout.PropertyField(targetObjectProp);

        // 사이에서 변경된 값이 있을 수 있으므로 적용
        serializedObject.ApplyModifiedProperties();
    }

    // SceneView에서의 GUI를 그리는 함수
    private void OnSceneGUI(SceneView obj)
    {
        // SceneView에 어떤 것을 drawing하기 위해서 사용하는 class
        Handles.Label(targetRef.transform.position, $"I am : {targetRef.gameObject.name}");
        var otherObjs = FindObjectsOfType<CustomScript>();

        for (int i = 0; i < otherObjs.Length; i++)
        {
            if (this.targetRef != otherObjs[i])
            {
                var pos = otherObjs[i].transform.position;
                Handles.DrawLine(targetRef.transform.position, pos);

                Handles.color = Color.red;
                Handles.DrawWireCube(pos, Vector3.one);
                Handles.color = Color.white;
            }
        }

        // 내가 선택한 오브젝트에 큐브를 그린다.
        Handles.DrawWireCube(targetRef.transform.position, new Vector3(2, 3, 2));

        Handles.BeginGUI();
        {
            if (GUILayout.Button("MoveRight!"))
            {
                targetRef.transform.position += new Vector3(1, 0, 0);
            }

            if (GUILayout.Button("MoveLeft!"))
            {
                targetRef.transform.position += new Vector3(-1, 0, 0);
            }
        }
        Handles.EndGUI();

    }
}