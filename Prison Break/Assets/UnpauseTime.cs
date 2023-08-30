using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpauseTime : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 1.0f;
    }
}
