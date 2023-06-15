using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Make it a singleton 
    public static void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static void NextLevel()
    {
        // Check if there is another level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
