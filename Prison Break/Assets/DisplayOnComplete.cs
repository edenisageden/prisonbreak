using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayOnComplete : MonoBehaviour
{
    [SerializeField] private NextLevelBox nextLevelBox;
    [SerializeField] private Animator animator;

    private void LateUpdate()
    {
        if (nextLevelBox.isCompleteFully)
        {
            Time.timeScale = 1.0f;
            animator.SetBool("isComplete", true);
        }
    }
}
