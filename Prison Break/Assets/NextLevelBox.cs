using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelBox : MonoBehaviour
{
    [SerializeField] private Collider2D col;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool hasCollided = collision.gameObject.layer == LayerMask.NameToLayer("Player");
        if (hasCollided && GetEnemies().Length == 0) LevelManager.NextLevel();
    }
    private GameObject[] GetEnemies()
    {
        return GameObject.FindGameObjectsWithTag("Enemy");
    }
}
