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
            animator.SetBool("isComplete", true);
        }
    }
}
