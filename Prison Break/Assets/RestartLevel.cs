using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (!player.activeSelf) LevelManager.RestartLevel();
        }
    }
}
