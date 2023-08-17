using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corpseAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        animator.SetInteger("deathIndex", Random.Range(1, 4));
    }
}
