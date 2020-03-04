using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(Dog_Cursor))]
public class Dog_CursorEditor : Editor
{
    void OnSceneGUI() {
        Dog_Cursor cursor = (Dog_Cursor)target;

        Handles.color = Color.red;
		Handles.DrawWireCube(cursor.mousePosition, new Vector3(1f, 1f, 1f));
    }
}
