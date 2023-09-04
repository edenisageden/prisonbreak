using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessingOnOffManager : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetInt("PostProcessing") == 0) GameObject.FindGameObjectWithTag("PostProcessing").SetActive(false); 
    }
}
