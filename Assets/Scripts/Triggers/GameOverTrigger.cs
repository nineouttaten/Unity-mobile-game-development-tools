using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    public string collisionTagOfObject;
    public GameObject gameOverUI;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(collisionTagOfObject))
        {
            gameOverUI.SetActive(true);
        }
    }
}
