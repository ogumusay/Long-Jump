using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadStartMenu()
    {
        StartCoroutine(LoadAsynchronusly("Start Menu"));
    }

    public void LoadEndlessGame()
    {
        StartCoroutine(LoadAsynchronusly("Endless Game"));
    }

    public void LoadShop()
    {
        StartCoroutine(LoadAsynchronusly("Shop"));
    }

    public void LoadBlank()
    {
        StartCoroutine(LoadAsynchronusly("Blank Scene"));
    }

    public void LoadLevelList()
    {
        StartCoroutine(LoadAsynchronusly("Level List"));
    }

    public void LoadGame()
    {
        StartCoroutine(LoadAsynchronusly("Game"));
    }
    
    public void LoadNextLevel()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel");
        int nextLevel = currentLevel + 1;
        PlayerPrefs.SetInt("currentLevel", nextLevel);

        LoadGame();

    }

    private IEnumerator LoadAsynchronusly(string sceneName)
    {
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(sceneName);

        while (!loadScene.isDone)
        {
            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
