using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovingGroupToPoints : MonoBehaviour
{
    public string nameOfObjectsGroup;

    public Transform[] points;

    public bool randomPoint;
    
    public float speedMultiplier;

    public bool randomSpeed;
    
    public float minRandomSpeed;
    public float maxRandomSpeed;

    public bool plusSpeedEveryNew;
    
    public float plusSpeed;

    public bool boundsOfSpeed;
    
    public float minSpeed;
    public float maxSpeed;

    private float currentPlus;
    private Vector3 directionOfMoving;
    [NonSerialized]public Transform currentPoint;
    private int currentPointIndex;
    public void NewMovingObject()
    {
        if (plusSpeedEveryNew)
        {
            currentPlus += plusSpeed;
            speedMultiplier += plusSpeed;
        }
        if (randomSpeed)
        {
            var speed = Random.Range(minRandomSpeed, maxRandomSpeed);
            
            speedMultiplier = speed + currentPlus;
        }

        if (boundsOfSpeed)
        {
            CheckAndMakeBoundsOfSpeed();
        }

        if (randomPoint)
        {
            currentPoint = points[Random.Range(0, points.Length)];
        }
        else
        {
            currentPointIndex += 1;
            if (currentPointIndex >= points.Length)
            {
                currentPointIndex = 0;
            }

            currentPoint = points[currentPointIndex];
        }
    }

    private void CheckAndMakeBoundsOfSpeed()
    {
        if (speedMultiplier > maxSpeed)
        {
            speedMultiplier = maxSpeed;
        }
        
        if (speedMultiplier < minSpeed)
        {
            speedMultiplier = minSpeed;
        }
    }
}
