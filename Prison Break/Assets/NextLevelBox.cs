using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelBox : MonoBehaviour
{
    [SerializeField] private Collider2D col;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private bool goToMenu = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool hasCollided = collision.gameObject.layer == LayerMask.NameToLayer("Player");
        if (hasCollided && GetEnemies().Length == 0)
        {
            LevelManager.CompleteLevel(timeManager.time);
            if (!goToMenu)
            {
                LevelManager.NextLevel();
            }
            else
            {
                LevelManager.OpenLevel(-1);
            }
        }
    }
    private GameObject[] GetEnemies()
    {
        return GameObject.FindGameObjectsWithTag("Enemy");
    }
}
