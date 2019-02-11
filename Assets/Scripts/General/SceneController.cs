using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    bool LoadingInitiated;
    //GameObject[] PauseMenuObjects;
    public AudioSource Menuforward;
    public AudioSource Menubackward;

    void Awake()
    {
        bool LoadingInitiated = false;
    }

    public void LevelOneClick()
    {
        if (!LoadingInitiated)
        {
            StartCoroutine(LevelOneload());
            LoadingInitiated = true;
        }
    }
    IEnumerator LevelOneload()
    {
        Time.timeScale = 1;
        Menuforward.Play();
        yield return new WaitForSeconds(Menuforward.clip.length);
        SceneManager.LoadScene(1);
        Debug.Log("Game started");
    }

    public void MainMenuClick()
    {
        if (!LoadingInitiated)
        {
            StartCoroutine(MainMenuLoad());
            LoadingInitiated = true;
        }
    }
    IEnumerator MainMenuLoad()
    {
        Time.timeScale = 1;
        Menubackward.Play();
        yield return new WaitForSeconds(Menubackward.clip.length);
        SceneManager.LoadScene(0);
        Debug.Log("Menu Loaded");
    }

    public void CloseGameClick()
    {
        if (!LoadingInitiated)
        {
            StartCoroutine(CloseGameLoad());
            LoadingInitiated = true;
        }
    }
    IEnumerator CloseGameLoad()
    {
        Time.timeScale = 1;
        Menubackward.Play();
        yield return new WaitForSeconds(Menubackward.clip.length);
        Application.Quit();
    }
}
