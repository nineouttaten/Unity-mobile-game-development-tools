using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    public Vector3 speed;
    
    public bool getGroupSpeed;
    
    public string nameOfObjectsGroup;

    private List<MovingGroup> movingGroupScript = new List<MovingGroup>();
    private List<MovingGroupToPoints> movingGroupToPoints = new List<MovingGroupToPoints>();

    private void Start()
    {
        MovingGroup[] movingGroups = FindObjectsOfType<MovingGroup>();
        MovingGroupToPoints[] movingGroupsToPoints = FindObjectsOfType<MovingGroupToPoints>();
        if (!getGroupSpeed)
        {
            return;
        }
        foreach (MovingGroup obj in movingGroups)
        {
            if (obj.nameOfObjectsGroup == nameOfObjectsGroup)
            {
                //movingGroupScript = obj;
                movingGroupScript.Add(obj);
            }
        }
        foreach (MovingGroupToPoints obj in movingGroupsToPoints)
        {
            if (obj.nameOfObjectsGroup == nameOfObjectsGroup)
            {
                //movingGroupToPoints = obj;
                movingGroupToPoints.Add(obj);
            }
        }

        if ((movingGroupScript.Count == 0) & (movingGroupToPoints.Count == 0))
        {
            print("error, no such group");
            return;
        }
        if ((movingGroupScript.Count > 1) || (movingGroupToPoints.Count > 1))
        {
            print("error, too much group scripts with this name");
            return;
        }

        if (movingGroupScript.Count == 1)
        {
            movingGroupScript[0].NewMovingObject();
            speed = movingGroupScript[0].speed;
            return;
        }

        if (movingGroupToPoints.Count == 1)
        {
            movingGroupToPoints[0].NewMovingObject();
            speed = (movingGroupsToPoints[0].currentPoint.position - gameObject.transform.position) * movingGroupToPoints[0].speedMultiplier;
        }

    }

    private void Update()
    {
        gameObject.transform.position += speed * Time.deltaTime;
    }
}
