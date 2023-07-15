using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject player;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("esc");
            OpenMenu();
        }
    }

    public void OpenMenu()
    {
        // Deactivate everything
        panel.SetActive(true);
        PauseTime();
    }
    public void CloseMenu()
    {
        panel.SetActive(false);
        StartTime();
    }
    public void PauseTime()
    {
        Time.timeScale = 0f;
        player.GetComponent<FaceCursor>().enabled = false;
        player.GetComponent<WeaponHolder>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<Pickup>().enabled = false;
    }
    public void StartTime()
    {
        Time.timeScale = 1f;
        player.GetComponent<FaceCursor>().enabled = true;
        player.GetComponent<WeaponHolder>().enabled = true;
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<Pickup>().enabled = true;
    }
}
