using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadLevelDelay = 2f;
    [SerializeField] ParticleSystem leftLaser;
    [SerializeField] ParticleSystem rightLaser;

    bool isTransitioning = false;

    void OnTriggerEnter(Collider other)
    {
        if (isTransitioning) { return; }

        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        GetComponent<PlayerControlles>().enabled = false;
        leftLaser.Stop();
        rightLaser.Stop();
        Invoke("ReloadLevel", loadLevelDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
