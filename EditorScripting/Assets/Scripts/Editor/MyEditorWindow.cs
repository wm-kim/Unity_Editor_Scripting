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

    int intValue;
    float floatValue;
    Color colorvalue;
    Gradient gradientValue = new Gradient();
    Vector3 vector3Value;
    Vector3Int vector3IntValue;
    Rect rectValue;
    UnityEngine.Object objectValue;
    string passwordValue;
    string tagValue;
    UnityEngine.ParticleSystemCollisionType enumValue;
    bool toggleValue;
    string[] stringArr = new string[] { "string01", "string02", "string03", "string04", "string05", "string06" };
    int selectionValue;

    private void OnGUI()
    {
        #region ====::EditiorGUILayout::====

        // Int Field
        intValue = EditorGUILayout.IntField("Int 값", intValue);

        // Float Field
        floatValue = EditorGUILayout.FloatField("Float 값", floatValue);

        // Color Field
        colorvalue = EditorGUILayout.ColorField("Color 값", colorvalue);

        // Gradient Field
        gradientValue = EditorGUILayout.GradientField("Gradient 값", gradientValue);

        // Vector3 Field
        vector3Value = EditorGUILayout.Vector3Field("Vector3 값", vector3Value);

        // Vector3Int Field
        vector3IntValue = EditorGUILayout.Vector3IntField("Vector3Int 값", vector3IntValue);

        // Rect Field
        rectValue = EditorGUILayout.RectField("Rect 값", rectValue);

        // Object Field
        objectValue = EditorGUILayout.ObjectField("Object 값", objectValue, typeof(GameObject), true);

        // Password Field
        passwordValue = EditorGUILayout.PasswordField("Password 값", passwordValue);

        // Tag Field
        tagValue = EditorGUILayout.TagField("Tag 값", tagValue);

        EditorGUILayout.Space(15);

        // Enum Type Field
        enumValue = (UnityEngine.ParticleSystemCollisionType)EditorGUILayout.EnumPopup("Enum 값", enumValue);

        // Slider
        floatValue = EditorGUILayout.Slider("Slider 값", floatValue, 0, 100);

        // HelpBox
        EditorGUILayout.HelpBox("HelpBox", MessageType.Error);

        // Toggle
        toggleValue = EditorGUILayout.Toggle("Toggle 값", toggleValue);

        // 줄 긋기
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        #endregion

        #region ====::GUILayout::====

        // ToolBar
        selectionValue = GUILayout.Toolbar(selectionValue, stringArr);
        GUILayout.Space(15);

        // Selection Grid
        // https://github.com/halak/unity-editor-icons
        selectionValue = GUILayout.SelectionGrid(selectionValue, stringArr, 2);

        // Box (e.g. Texture)
        GUILayout.Box(EditorGUIUtility.IconContent("Animation.Record"), GUILayout.Width(100), GUILayout.Height(100));

        #endregion
    }
}

