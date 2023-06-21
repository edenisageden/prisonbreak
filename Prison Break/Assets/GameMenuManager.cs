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
        Time.timeScale = 0f;
        player.GetComponent<FaceCursor>().enabled = false;
    }
    public void CloseMenu()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        player.GetComponent<FaceCursor>().enabled = true;

    }
}
