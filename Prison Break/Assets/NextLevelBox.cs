using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelBox : MonoBehaviour
{
    [SerializeField] private Collider2D col;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private GameObject ammoMenu;
    [SerializeField] private bool goToMenu = false;
    [SerializeField] private GameObject completionMenu;
    [SerializeField] private GameMenuManager gameMenuManager;
    [SerializeField] private TMP_Text time, best, nextMedal, timer;
    [SerializeField] private LevelInfoSO levelInfoSO;
    [SerializeField] private GameObject player;
    [SerializeField] private Color bronzeColor, silverColor, goldColor;
    public static event Action OnComplete = delegate { };
    private bool hasInvokedComplete = false;
    public bool isComplete;
    public bool isCompleteFully;

    public enum Medal
    {
        Bronze,
        Silver,
        Gold
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool hasCollided = collision.gameObject.layer == LayerMask.NameToLayer("EnvironmentCollider");
        if (hasCollided && GetEnemies().Length == 0)
        {
            LevelManager.CompleteLevel(timeManager.time);
            if (!goToMenu)
            {
                isCompleteFully = true;
                PauseTime();
                InitializeCompletionMenu();
                completionMenu.SetActive(true);
                timer.enabled = false;
                ammoMenu.SetActive(false);
            }
            else
            {
                Utility.OpenScene("mainmenu");
            }
        }
    }
    private GameObject[] GetEnemies()
    {
        return GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void Update()
    {
        if (GetEnemies().Length == 0)
        {
            if (hasInvokedComplete) return;
            hasInvokedComplete = true;
            OnComplete?.Invoke();
            isComplete = true;
        }
    }

    public void NextLevel()
    {
        completionMenu.SetActive(false);
        StartTime();
        timer.enabled = true;
        ammoMenu.SetActive(true);
        Utility.OpenNextScene();
    }
    public void OpenMenu()
    {
        completionMenu.SetActive(false);
        StartTime();
        timer.enabled = true;
        ammoMenu.SetActive(true);
        Utility.OpenScene("mainmenu");
    }
    public void Retry()
    {
        completionMenu.SetActive(false);
        StartTime();
        timer.enabled = true;
        ammoMenu.SetActive(true);
        Utility.ReloadScene();
    }

    private void InitializeCompletionMenu()
    {
        float bestTime = PlayerPrefs.GetFloat("CompleteTime" + LevelManager.GetCurrentLevel());
        float silverTime = levelInfoSO.silverTime;
        float goldTime = levelInfoSO.goldTime;
        print(timeManager.time);
        time.text = timeManager.time.ToString("f1");
        best.text = bestTime.ToString("f1");
        switch (GetMedal(bestTime))
        {
            case Medal.Bronze:
                nextMedal.text = silverTime.ToString();
                nextMedal.color = silverColor;
                best.color = bronzeColor;
                break;
            case Medal.Silver:
                nextMedal.text = goldTime.ToString();
                nextMedal.color = goldColor;
                best.color = silverColor;
                break;
            case Medal.Gold:
                nextMedal.text = "";
                best.color = goldColor;
                break;
        }
        switch (GetMedal(timeManager.time))
        {
            case Medal.Bronze:
                time.color = bronzeColor;
                break;
            case Medal.Silver:
                time.color = silverColor;
                break;
            case Medal.Gold:
                time.color = goldColor;
                break;
        }
    }

    private Medal GetMedal(float time)
    {
        if (time <= levelInfoSO.goldTime) return Medal.Gold;
        else if (time <= levelInfoSO.silverTime) return Medal.Silver;
        else return Medal.Bronze;
    }

    public void PauseTime()
    {
        Time.timeScale = 0f;
        player.GetComponent<FaceCursor>().enabled = false;
        player.GetComponent<WeaponHolder>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<Pickup>().enabled = false;
        gameMenuManager.enabled = false;
    }
    public void StartTime()
    {
        Time.timeScale = 1f;
        player.GetComponent<FaceCursor>().enabled = true;
        player.GetComponent<WeaponHolder>().enabled = true;
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<Pickup>().enabled = true;
        gameMenuManager.enabled = true;
    }
}
