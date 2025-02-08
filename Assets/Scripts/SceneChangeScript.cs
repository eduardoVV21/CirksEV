using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    public FadeScript fadeScript;
    public SaveLoadScript saveLoadScript;
    public void CloseGame()
    {
        StartCoroutine(Delay("quit", -1, ""));
    }

    public void OpenSettings()
    {
        StartCoroutine(Delay("settings", -1, ""));
    }

    public void ReturnToMain()
    {
        StartCoroutine(Delay("main", -1, ""));
    }

    public IEnumerator Delay(string command, int characterIndex, string name)
    {
        if(string.Equals(command, "quit", StringComparison.OrdinalIgnoreCase))
        {
            yield return fadeScript.FadeIn(0.05f);
            PlayerPrefs.DeleteAll();
            Application.Quit();
        
        } else if(string.Equals(command, "play", StringComparison.OrdinalIgnoreCase))
        {
            yield return fadeScript.FadeIn(0.05f);
           
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        else if (string.Equals(command, "settings", StringComparison.OrdinalIgnoreCase))
        {
            yield return fadeScript.FadeIn(0.05f);

            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
        else if (string.Equals(command, "main", StringComparison.OrdinalIgnoreCase))
        {
            yield return fadeScript.FadeIn(0.025f);
            saveLoadScript.SaveGame(characterIndex, name);
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
