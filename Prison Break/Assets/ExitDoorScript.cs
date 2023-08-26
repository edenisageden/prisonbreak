using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorScript : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        NextLevelBox.OnComplete += OpenDoor;
    }
    private void OnDestroy()
    {
        NextLevelBox.OnComplete -= OpenDoor;
    }

    private void OpenDoor()
    {
        animator.Play("DoorOpening");
    }
}
