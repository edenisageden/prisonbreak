using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayOnComplete : MonoBehaviour
{
    [SerializeField] private NextLevelBox nextLevelBox;
    [SerializeField] private GameObject thingToDisplay;

    private void Update()
    {
        if (nextLevelBox.isComplete) thingToDisplay.SetActive(true);
    }
}
