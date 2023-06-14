using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MovingGroupToPoints))]
[CanEditMultipleObjects]
public class MovingGroupToPointsEditor : Editor
{
    private SerializedProperty nameOfObjectsGroup;
    private SerializedProperty points;
    private SerializedProperty randomPoint;
    private SerializedProperty speedMultiplier;
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
        points = serializedObject.FindProperty("points");
        randomPoint = serializedObject.FindProperty("randomPoint");
        speedMultiplier = serializedObject.FindProperty("speedMultiplier");
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
        MovingGroupToPoints movingGroup = (MovingGroupToPoints)target;
        serializedObject.Update();
        
        EditorGUILayout.PropertyField(nameOfObjectsGroup);

        EditorGUILayout.PropertyField(points);
        EditorGUILayout.PropertyField(randomPoint);
        
        EditorGUI.BeginDisabledGroup(movingGroup.randomSpeed);
        EditorGUILayout.PropertyField(speedMultiplier);
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
