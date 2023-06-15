using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            LevelManager.RestartLevel();
        }
    }
}
