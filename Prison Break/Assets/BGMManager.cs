using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private GameObject BGM1, BGM2, BGM3, BGM3dash5, BGM4;

    private void Awake()
    {
        // Singleton
        GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("BGM");
        if (musicObjects.Length > 1) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (IsBGMScene1())
        {
            BGM1.SetActive(true);
            BGM2.SetActive(false);
            BGM3.SetActive(false);
            BGM3dash5.SetActive(false);
            BGM4.SetActive(false);
        }
        if (IsBGMScene2())
        {
            BGM1.SetActive(false);
            BGM2.SetActive(true);
            BGM3.SetActive(false);
            BGM3dash5.SetActive(false);
            BGM4.SetActive(false);
        }
        if (IsBGMScene3())
        {
            BGM1.SetActive(false);
            BGM2.SetActive(false);
            BGM3.SetActive(true);
            BGM3dash5.SetActive(false);
            BGM4.SetActive(false);
        }
        if (IsBGMScene3dash5())
        {
            BGM1.SetActive(false);
            BGM2.SetActive(false);
            BGM3.SetActive(false);
            BGM3dash5.SetActive(true);
            BGM4.SetActive(false);
        }
        if (IsBGMScene4())
        {
            BGM1.SetActive(false);
            BGM2.SetActive(false);
            BGM3.SetActive(false);
            BGM3dash5.SetActive(false);
            BGM4.SetActive(true);
        }
    }

    private bool IsBGMScene1()
    {
        if (SceneManager.GetActiveScene().name == "mainmenu" || SceneManager.GetActiveScene().name == "settings") return true;
        else return false;
    }
    private bool IsBGMScene2()
    {
        if (
            SceneManager.GetActiveScene().name == "level1" || 
            SceneManager.GetActiveScene().name == "level2" ||
            SceneManager.GetActiveScene().name == "level3" ||
            SceneManager.GetActiveScene().name == "level4" ||
            SceneManager.GetActiveScene().name == "level5" ||
            SceneManager.GetActiveScene().name == "level6" ||
            SceneManager.GetActiveScene().name == "level7" ||
            SceneManager.GetActiveScene().name == "level8" ||
            SceneManager.GetActiveScene().name == "level9" ||
            SceneManager.GetActiveScene().name == "level0" 
            ) return true;
        else return false;
    }
    private bool IsBGMScene3()
    {
        if (SceneManager.GetActiveScene().name == "level10" && !FindAnyObjectByType<BossLogic>().isPhase2) return true;
        else return false;
    }
    private bool IsBGMScene3dash5()
    {
        if (SceneManager.GetActiveScene().name == "level10" && FindAnyObjectByType<BossLogic>().isPhase2) return true;
        else return false;
    }
    private bool IsBGMScene4()
    {
        if (SceneManager.GetActiveScene().name == "levelselection") return true;
        else return false;
    }
}
