using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(PlayerData))]
public class PlayerDataDrawer : PropertyDrawer
{
    /*
     * 주의 : PropertyDrawer에서의 OnGUI에서는 EditorGUILayout/GUILayout 류의 자동 layout class가 아니다.
     */

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.Box(position, GUIContent.none, GUI.skin.window);

        EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        {
            EditorGUI.indentLevel++;

            var rt = new Rect(position.x, position.y + GUIStyle.none.CalcSize(label).y + 2, position.width, 16);

            foreach(SerializedProperty prop in property)
            {
                GUI.color = new Color(Random.value, Random.value, Random.value);
                EditorGUI.PropertyField(rt, prop);
                rt.y += 18;
            }

            GUI.color = Color.white;

            EditorGUI.indentLevel--;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        int cnt = 0;
        foreach (var prop in property)
        {
            cnt++;
        }
        
        return EditorGUIUtility.singleLineHeight * (cnt + 1) + 6;
    }
}
