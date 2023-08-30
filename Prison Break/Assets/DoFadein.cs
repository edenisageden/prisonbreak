using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class DoFadein : MonoBehaviour
{
    [SerializeField] NextLevelBox nextLevelBox;
    [SerializeField] Animator animator;

    private void Update()
    {
        if (nextLevelBox.isCompleteFully) animator.SetBool("isComplete", true);
    }
}
