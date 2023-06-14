using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public string collisionTagOfObject;
    public int valueOfTriggering;
    public TMP_Text scoreText;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("touch");
        if (other.gameObject.CompareTag(collisionTagOfObject))
        {
            scoreText.text = (int.Parse(scoreText.text) + valueOfTriggering).ToString();
        }
    }


}
