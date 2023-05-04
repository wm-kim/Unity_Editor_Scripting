using Codice.Client.BaseCommands.BranchExplorer.Layout;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CustomScript))]
public class CustomEditorTest : Editor
{
    CustomScript targetRef;

    SerializedProperty targetObjectProp;
    SerializedProperty nameProp;
    SerializedProperty hpProp;

    private void OnEnable()
    {
        // 데이터 타입을 명시하지 않음 (Generic)
        targetObjectProp = serializedObject.FindProperty($"{nameof(CustomScript.otherObject)}");
        nameProp = serializedObject.FindProperty($"{nameof(CustomScript.myName)}");
        hpProp = serializedObject.FindProperty($"{nameof(CustomScript.myHP)}");

        targetRef = (CustomScript)base.target;
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
}
