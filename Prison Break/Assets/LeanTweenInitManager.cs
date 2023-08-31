using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanTweenInitManager : MonoBehaviour
{
    private void OnEnable()
    {
        LeanTween.reset();
        LeanTween.init();
    }
}
