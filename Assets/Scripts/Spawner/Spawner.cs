using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public float timeToSpawn;
    public bool randomTime;
    public float minTime = 0;
    public float maxTime = 5;
    
    public GameObject[] objectsToSpawn;
    public bool randomObject;
    
    public Transform[] spawnPoints;
    public bool randomSpawn;
    /*[NonSerialized]*/public bool randomRangeBetweenPoints;
    
    private int currentObjectIndex;
    private int currentSpawnPointIndex;

    private void Start()
    {
        currentObjectIndex = objectsToSpawn.Length - 1;
        currentSpawnPointIndex = spawnPoints.Length - 1;
        StartCoroutine(SpawnWithTimer());
        //if (PlayerPrefs.GetInt("ToggleTime") == 1)
        //{
        //    randomRangeBetweenPoints = true;
       /// }
        
    }

    private int GetIndexOfObjectToSpawn()
    {
        if (randomObject)
        {
            return Random.Range(0, objectsToSpawn.Length);
        }
        else
        {
            currentObjectIndex += 1;
            if (currentObjectIndex == objectsToSpawn.Length)
            {
                currentObjectIndex = 0;
            }
            print(currentObjectIndex);
            return currentObjectIndex;
        }
    }
    private int GetIndexOfPointToSpawn()
    {
        if (randomSpawn)
        {
            return Random.Range(0, spawnPoints.Length);
        }
        else
        {
            currentSpawnPointIndex += 1;
            if (currentSpawnPointIndex == spawnPoints.Length)
            {
                currentSpawnPointIndex = 0;
            }
            

            return currentSpawnPointIndex;
        }
    }
    private void SpawnObject(int objInd, int spwnInd)
    {
        if (randomRangeBetweenPoints)
        {
            Instantiate(objectsToSpawn[objInd], TransformExtensions.FindRandomWithinBounds(spawnPoints),
                spawnPoints[spwnInd].rotation);
        }
        else
        {
            Instantiate(objectsToSpawn[objInd], spawnPoints[spwnInd].position, spawnPoints[spwnInd].rotation);
        }
    }
    
    IEnumerator SpawnWithTimer()
    {
        SpawnObject(GetIndexOfObjectToSpawn(),GetIndexOfPointToSpawn());
        if (randomTime)
        {
            timeToSpawn = Random.Range(minTime, maxTime);
        }
        yield return new WaitForSeconds(timeToSpawn);
        StartCoroutine(SpawnWithTimer());
    }
    
    
    public static class TransformExtensions
    {
        public static Vector3 FindRandomWithinBounds(Transform[] transforms)
        {
            Bounds bounds = GetBounds(transforms);
            Vector3 randomPoint = new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z));

            //Collider[] colliders = Physics.OverlapSphere(randomPoint, 0.1f); // использовать ту же коллизию, что и у transforms

            // for (int i = 0; i < colliders.Length; i++)
            // {
            return randomPoint;
        }

        private static Bounds GetBounds(Transform[] transforms)
        {
            if (transforms.Length == 1)
            {
                return new Bounds(transforms[0].position, Vector3.zero);
            }

            Vector3 min = transforms[0].position;
            Vector3 max = transforms[0].position;

            for (int i = 1; i < transforms.Length; i++)
            {
                min = Vector3.Min(min, transforms[i].position);
                max = Vector3.Max(max, transforms[i].position);
            }

            return new Bounds((min + max) / 2f, max - min);
        }
    }
}
