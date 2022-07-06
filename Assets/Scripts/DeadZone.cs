using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var other = collision.transform;
        if (other.CompareTag("Platform"))
        {
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Player"))
        {
            levelManager.LoseGame();
        }
    }
}
