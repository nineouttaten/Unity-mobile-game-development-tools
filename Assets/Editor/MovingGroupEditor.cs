using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MovingGroup))]
[CanEditMultipleObjects]
public class MovingGroupEditor : Editor
{
    private SerializedProperty nameOfObjectsGroup;
    private SerializedProperty speed;
    private SerializedProperty randomSpeed;
    private SerializedProperty minRandomSpeed;
    private SerializedProperty maxRandomSpeed;
    private SerializedProperty plusSpeedEveryNew;
    private SerializedProperty plusSpeed;
    private SerializedProperty boundsOfSpeed;
    private SerializedProperty minSpeed;
    private SerializedProperty maxSpeed;

    void OnEnable()
    {
        nameOfObjectsGroup = serializedObject.FindProperty("nameOfObjectsGroup"); 
        speed = serializedObject.FindProperty("speed");
        randomSpeed = serializedObject.FindProperty("randomSpeed");
        minRandomSpeed = serializedObject.FindProperty("minRandomSpeed");
        maxRandomSpeed = serializedObject.FindProperty("maxRandomSpeed");
        plusSpeedEveryNew = serializedObject.FindProperty("plusSpeedEveryNew");
        plusSpeed = serializedObject.FindProperty("plusSpeed");
        boundsOfSpeed = serializedObject.FindProperty("boundsOfSpeed");
        minSpeed = serializedObject.FindProperty("minSpeed");
        maxSpeed = serializedObject.FindProperty("maxSpeed");
    }

    public override void OnInspectorGUI()
    {
        MovingGroup movingGroup = (MovingGroup)target;
        serializedObject.Update();
        
        EditorGUILayout.PropertyField(nameOfObjectsGroup);
        
        EditorGUI.BeginDisabledGroup(movingGroup.randomSpeed);
        EditorGUILayout.PropertyField(speed);
        EditorGUI.EndDisabledGroup();
        
        EditorGUILayout.PropertyField(randomSpeed);

        var level = EditorGUI.indentLevel;
        EditorGUI.indentLevel++;
        EditorGUI.BeginDisabledGroup(!movingGroup.randomSpeed);
        EditorGUILayout.PropertyField(minRandomSpeed);
        EditorGUILayout.PropertyField(maxRandomSpeed);
        EditorGUI.EndDisabledGroup();
        EditorGUI.indentLevel = level;
        
        EditorGUILayout.PropertyField(plusSpeedEveryNew);
        
        EditorGUI.indentLevel++;
        EditorGUI.BeginDisabledGroup(!movingGroup.plusSpeedEveryNew);
        EditorGUILayout.PropertyField(plusSpeed);
        EditorGUI.EndDisabledGroup();
        EditorGUI.indentLevel = level;
        
        EditorGUILayout.PropertyField(boundsOfSpeed);
        
        EditorGUI.indentLevel++;
        EditorGUI.BeginDisabledGroup(!movingGroup.boundsOfSpeed);
        EditorGUILayout.PropertyField(minSpeed);
        EditorGUILayout.PropertyField(maxSpeed);
        EditorGUI.EndDisabledGroup();
        EditorGUI.indentLevel = level;
        
        serializedObject.ApplyModifiedProperties();
    }
}
