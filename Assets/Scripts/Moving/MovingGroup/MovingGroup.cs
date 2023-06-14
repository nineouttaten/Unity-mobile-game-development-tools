using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGroup : MonoBehaviour
{
    public string nameOfObjectsGroup;

    public Vector3 speed;
    
    public bool randomSpeed;
    
    public Vector3 minRandomSpeed;
    public Vector3 maxRandomSpeed;

    public bool plusSpeedEveryNew;
    
    public Vector3 plusSpeed;

    public bool boundsOfSpeed;
    public Vector3 minSpeed;
    public Vector3 maxSpeed;

    private Vector3 currentPlus;
    public void NewMovingObject()
    {
        if (plusSpeedEveryNew)
        {
            currentPlus += plusSpeed;
            speed += plusSpeed;
        }
        if (randomSpeed)
        {
            var speedX = Random.Range(minRandomSpeed.x, maxRandomSpeed.x);
            var speedY = Random.Range(minRandomSpeed.y, maxRandomSpeed.y);
            var speedZ = Random.Range(minRandomSpeed.z, maxRandomSpeed.z);
            speed = new Vector3(speedX, speedY, speedZ) + currentPlus;
        }

        if (boundsOfSpeed)
        {
            CheckAndMakeBoundsOfSpeed();
        }
    }

    private void CheckAndMakeBoundsOfSpeed()
    {
        if (speed.x > maxSpeed.x)
        {
            speed.x = maxSpeed.x;
        }
        if (speed.y > maxSpeed.y)
        {
            speed.y = maxSpeed.y;
        }
        if (speed.z > maxSpeed.z)
        {
            speed.z = maxSpeed.z;
        }
        if (speed.x < minSpeed.x)
        {
            speed.x = minSpeed.x;
        }
        if (speed.y < minSpeed.y)
        {
            speed.y = minSpeed.y;
        }
        if (speed.z < minSpeed.z)
        {
            speed.z = minSpeed.z;
        }
    }
}
