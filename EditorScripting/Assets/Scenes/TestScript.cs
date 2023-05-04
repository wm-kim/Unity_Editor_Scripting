using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    private void OnGUI()
    {
        GUI.Label(new Rect(100, 100, 200, 200), "This is gui Label");
        GUILayout.Label("This is guilayout!");
    }
}
