using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonobehaviourUtility: MonoBehaviour
{
    public static event Action OnDataDeleted = delegate { };

    public static void OpenScene(string name)
    {
        SceneManager.LoadScene(name.ToLower().Trim());
    }
    public static void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public static void OpenNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentIndex + 1);
        }
        else
        {
            Debug.LogError("Scene index is out of bounds");
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
        OnDataDeleted?.Invoke();
    }
    public static void CloseGame()
    {
        Application.Quit();
    }
}
