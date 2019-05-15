using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class MusicController : MonoBehaviour {

    public AudioSource audioStart;
    public AudioSource audioMenu;
    public AudioSource audioLevelNormal;
    public AudioSource audioLevelBoss;
    public AudioSource audioCredits;

    private AudioSource currentAudio;

    void Awake()
    {
        audioStart.Play();
        currentAudio = audioStart;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartGame());

    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Menu");

    }

    void Update()
    {
        string scene = SceneManager.GetActiveScene().name;
        switch (scene)
        {
            case "Start":
                if (currentAudio != audioStart)
                {
                    currentAudio.Stop();
                    currentAudio = audioStart;
                    currentAudio.Play();
                }
                break;
            case "Camp_1":
                int level = PlayerPrefs.GetInt("this_level");
                AudioSource aud;
                if (level % 5 == 0)
                    aud = audioLevelBoss;
                else
                    aud = audioLevelNormal;
                if(currentAudio != aud)
                {
                    currentAudio.Stop();
                    currentAudio = aud;
                    currentAudio.Play();
                }
                break;
            case "Creditos":
                if (currentAudio != audioCredits)
                {
                    currentAudio.Stop();
                    currentAudio = audioCredits;
                    currentAudio.Play();
                }
                break;
            default:
                if (currentAudio != audioMenu)
                {
                    currentAudio.Stop();
                    currentAudio = audioMenu;
                    currentAudio.Play();
                }
                break;
        }
    }
}
