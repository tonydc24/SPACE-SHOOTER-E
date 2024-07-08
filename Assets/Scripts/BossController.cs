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
        SpriteRenderer childRenderer = GetComponentInChildren<SpriteRenderer>();
        if (childRenderer != null)
        {
            StartCoroutine(ChangeColorRoutine(childRenderer));
        }

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

    private IEnumerator ChangeColorRoutine(SpriteRenderer renderer)
    {
        Color originalColor = renderer.color;

        renderer.color = Color.red;

        yield return new WaitForSeconds(0.5f);

        renderer.color = originalColor;
    }
}
