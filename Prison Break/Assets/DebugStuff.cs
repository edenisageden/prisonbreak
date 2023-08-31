using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugStuff : MonoBehaviour
{
    [SerializeField] private float timeScale;

    private void Update()
    {
        Time.timeScale = timeScale;
    }
}
