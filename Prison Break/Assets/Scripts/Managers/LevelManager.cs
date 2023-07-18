using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static void TryOpenLevel(int level)
    {
        // If level is unlocked in playerprefs
        string intName = "LevelUnlocked" + level;
        if (PlayerPrefs.GetInt(intName, 0) == 1) SceneManager.LoadScene(level + 2);
    }
    public static void CompleteLevel(float time)
    {
        int currentlevel = GetCurrentLevel();
        PlayerPrefs.SetInt("LevelComplete" + currentlevel, 1);
        if (PlayerPrefs.GetFloat("CompleteTime" + currentlevel) == 0) PlayerPrefs.SetFloat("CompleteTime" + currentlevel, time);
        else if (PlayerPrefs.GetFloat("CompleteTime" + currentlevel) > time) PlayerPrefs.SetFloat("CompleteTime" + currentlevel, time);
        UnlockLevel(currentlevel + 1);
    }
    private static void UnlockLevel(int level)
    {
        PlayerPrefs.SetInt("LevelUnlocked" + level, 1);
    }
    public static int GetCurrentLevel()
    {
        return SceneManager.GetActiveScene().buildIndex - 2;
    }
}
