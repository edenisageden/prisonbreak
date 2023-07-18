using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float time;
    [SerializeField] private TextMeshProUGUI timeText;

    private void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("F1");
    }
}
