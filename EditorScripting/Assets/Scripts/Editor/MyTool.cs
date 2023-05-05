using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyTool : EditorWindow
{

    [MenuItem("MyTool/MyTool")]
    static void Open()
    {
        var window = GetWindow<MyTool>();
        window.titleContent = new GUIContent("MyTool");
    }

    private void OnGUI()
    {
        #region ====::AssetDatabase::====
        if (GUILayout.Button("모든 Material 찾기"))
        {
            var resultGuid = AssetDatabase.FindAssets("t:Material");
            if (resultGuid != null)
            {
                for (int i = 0; i < resultGuid.Length; i++)
                {
                    var guid = resultGuid[i];
                    var path = AssetDatabase.GUIDToAssetPath(guid);

                    Debug.Log($"GUID : {guid}, Path: {path}, Guid from path: {AssetDatabase.GUIDFromAssetPath(path)}");
                }
            }
        }

        if (GUILayout.Button("모든 Material 로드 및 적용"))
        {
            // 모든 renderer를 찾아서 삭제
            var allRenderers = FindObjectsOfType<Renderer>();
            if(allRenderers != null)
            {
                for(int i = 0; i < allRenderers.Length; i++)
                {
                    GameObject.DestroyImmediate(allRenderers[i].gameObject);
                }
            }

            var resultGuid = AssetDatabase.FindAssets("t:Material");
            if (resultGuid != null)
            {
                for (int i = 0; i < resultGuid.Length; i++)
                {
                    var guid = resultGuid[i];
                    var path = AssetDatabase.GUIDToAssetPath(guid);

                    var loadedMat = AssetDatabase.LoadAssetAtPath<Material>(path);
                    if (loadedMat != null)
                    {
                        Debug.Log($"Material Loaded : {path}");

                        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cube.transform.position = new Vector3(i * 2, 0, 0);
                        cube.GetComponent<Renderer>().material = loadedMat;
                    }
                }
            }
        }

        if(GUILayout.Button("Asset 생성하기"))
        {
            var loadedMat = new Material(Shader.Find("Standard"));
            AssetDatabase.CreateAsset(loadedMat, $"Assets/MyMaterial{(int)Random.Range(0, 1000)}.mat");
        }
        #endregion
    }
}
