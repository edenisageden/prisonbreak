using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utility 
{
    public static void OpenScene(object scene)
    {
        if (scene is int index)
        {
            SceneManager.LoadScene(index);
        }
        else if (scene is string name)
        {
            SceneManager.LoadScene(name.ToLower().Trim());
        }
        else
        {
            Debug.LogError("Argument is not valid variable type");
        }
    }
    public static void OpenNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentIndex + 1);
        }
    }
    public static void ReloadScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }
    public static void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
    public static void CloseGame()
    {
        Application.Quit();
    }
}
