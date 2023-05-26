using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionsHandler : MonoBehaviour
{

    [SerializeField] float loadNextLevelEventDelay = 2;
    [SerializeField] float crashEventDelay = 3;

    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip victorySound;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem victoryParticles;

    AudioSource audioSource;

    bool isTransitioning = false;
    bool isNoCollisionCheat = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update() 
    {
        //CheatKeys();
    }

/*
    void CheatKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            isNoCollisionCheat = !isNoCollisionCheat;
        }
    }
*/

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || isNoCollisionCheat)
        {
            return;
        }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                break;
            
            case "Finish":
                LoadNextLevelEvent();
                break;
            default:
                CrashEvent();
                break;          
        }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void CrashEvent()
    {
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        Invoke ("ReloadLevel", crashEventDelay);
        audioSource.PlayOneShot(crashSound);
        crashParticles.Play();
    }

    void LoadNextLevelEvent()
    {
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        Invoke ("LoadNextLevel", loadNextLevelEventDelay);
        audioSource.PlayOneShot(victorySound);
        victoryParticles.Play();
    }
}
