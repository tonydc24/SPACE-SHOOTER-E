using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    // 5 PLAYER BULLETS DESTROYS BOSS => 10 PUNTOS
    [SerializeField]
    int health;


    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
