using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int health = 1;

    ScoreBoard scoreBoard;
    Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = Color.red;
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        health = health - 1;
        Debug.Log($"Enemy Health: {health}");
        if (health < 1)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        scoreBoard.IncreaseScore(100);
        ColorChangeBlack();
        Invoke("ColorChangeRed", 0.1f);
        Invoke("ColorChangeBlack", 0.1f);
        Invoke("ColorChangeRed", 0.1f);
        Invoke("ColorChangeBlack", 0.1f);
        Invoke("ColorChangeRed", 0.1f);
        Invoke("ColorChangeBlack", 0.1f);
        Invoke("ColorChangeRed", 0.1f);
    }

    void ColorChangeBlack()
    {
        renderer.material.color = Color.black;
    }
    
    void ColorChangeRed()
    {
        renderer.material.color = Color.red;
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
