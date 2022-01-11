using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SomeScript))]
public class SomeScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // 기본 인스펙터를 사용한다.

        EditorGUILayout.HelpBox("이것은 정보 박스", MessageType.Info);
        EditorGUILayout.HelpBox("이것은 경고 박스", MessageType.Warning);
        EditorGUILayout.HelpBox("이것은 에로 박스", MessageType.Error);
        EditorGUILayout.HelpBox("이것은 핼프 박스", MessageType.None);
    }
}
