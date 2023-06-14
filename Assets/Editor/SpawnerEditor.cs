using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(Spawner))]
[CanEditMultipleObjects]
public class SpawnerEditor : Editor
{
    //bool togglePoints;
    //bool toggleTime;
    private SerializedProperty togglePoints;
    private SerializedProperty toggleTime;
    
    public SerializedProperty randomRange;

    private SerializedProperty TimeToSpawn;
    private SerializedProperty MinTime;
    private SerializedProperty MaxTime;
    private SerializedProperty ObjectsToSpawn;
    private SerializedProperty RandomObject;
    private SerializedProperty SpawnPoints;
    private SerializedProperty RandomSpawn;
    
    private bool foldoutTime = true;
    private bool foldoutObjects = true;
    private bool foldoutPoints = true;

    void OnEnable()
    {
        Spawner spawner = (Spawner)target;
        
        // Setup the SerializedProperties.
        TimeToSpawn = serializedObject.FindProperty("timeToSpawn");
        MinTime = serializedObject.FindProperty("minTime");
        MaxTime = serializedObject.FindProperty("maxTime");
        ObjectsToSpawn = serializedObject.FindProperty("objectsToSpawn");
        RandomObject = serializedObject.FindProperty("randomObject");
        SpawnPoints = serializedObject.FindProperty("spawnPoints");
        RandomSpawn = serializedObject.FindProperty("randomSpawn");
        
        //togglePoints = PlayerPrefs.GetInt("TogglePoints", 0) == 1;
        //toggleTime = PlayerPrefs.GetInt("ToggleTime", 0) == 1;
        togglePoints = serializedObject.FindProperty("randomRangeBetweenPoints");
        toggleTime = serializedObject.FindProperty("randomTime");
        //spawner.randomRangeBetweenPoints = togglePoints;
        //spawner.randomTime = toggleTime;
    }
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        Spawner spawner = (Spawner)target;
        serializedObject.Update();
        
        foldoutTime = EditorGUILayout.Foldout(foldoutTime, "Time",true, EditorStyles.foldoutHeader);
        if (foldoutTime)
        {
            var level = EditorGUI.indentLevel;
            EditorGUI.indentLevel++;
            
            EditorGUI.BeginDisabledGroup(spawner.randomTime);
            EditorGUILayout.PropertyField(TimeToSpawn);
            EditorGUI.EndDisabledGroup();
        
            //toggleTime = EditorGUILayout.Toggle("Random time", toggleTime);
            EditorGUILayout.PropertyField(toggleTime);
            
            EditorGUI.BeginDisabledGroup(!spawner.randomTime);
            EditorGUILayout.PropertyField(MinTime);
            EditorGUILayout.PropertyField(MaxTime);
            EditorGUI.EndDisabledGroup();
            
            EditorGUI.indentLevel = level;
        }

        foldoutObjects = EditorGUILayout.Foldout(foldoutObjects, "Objects",true, EditorStyles.foldoutHeader);
        if (foldoutObjects)
        {
            var level = EditorGUI.indentLevel;
            EditorGUI.indentLevel++;

            EditorGUILayout.PropertyField(ObjectsToSpawn);
            EditorGUILayout.PropertyField(RandomObject);
            
            EditorGUI.indentLevel = level;
        }
        
        foldoutPoints = EditorGUILayout.Foldout(foldoutPoints, "Points",true, EditorStyles.foldoutHeader);
        if (foldoutPoints)
        {
            var level = EditorGUI.indentLevel;
            EditorGUI.indentLevel++;

            EditorGUILayout.PropertyField(SpawnPoints);
            EditorGUILayout.PropertyField(RandomSpawn);
        
            EditorGUI.BeginDisabledGroup(!spawner.randomSpawn); //<---
            //togglePoints = EditorGUILayout.Toggle("Range between points", togglePoints.boolValue);
            EditorGUILayout.PropertyField(togglePoints);
            EditorGUI.EndDisabledGroup();
            
            EditorGUI.indentLevel = level;
        }
        
        if (GUI.changed)
        {
            //PlayerPrefs.SetInt("TogglePoints", togglePoints ? 1 : 0);
            //PlayerPrefs.SetInt("ToggleTime", toggleTime ? 1 : 0);
            //spawner.randomRangeBetweenPoints = togglePoints;
            //spawner.randomTime = toggleTime;
        }
        
        serializedObject.ApplyModifiedProperties();
    }
}
