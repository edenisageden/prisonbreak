using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPauseManager : MonoBehaviour
{
    [SerializeField] private BossDashLogic bossDashLogic;
    [SerializeField] private BossLogic bossLogic;
    [SerializeField] private AIDestinationSetter aIDestinationSetter;
    [SerializeField] private GameMenuManager gameMenuManager;
    [SerializeField] private AIPath aIPath;
    [SerializeField] private Animator animator;


    private void Update()
    {
        if (gameMenuManager.isPaused)
        {
            Time.timeScale = 0f;
            bossDashLogic.enabled = false;
            bossLogic.enabled = false;
            aIDestinationSetter.enabled = false;
            aIPath.enabled = false;
            animator.enabled = false;
        }
        else
        {
            Time.timeScale = 1f;
            bossDashLogic.enabled = true;
            bossLogic.enabled = true;
            aIDestinationSetter.enabled = true;
            aIPath.enabled = true;
            animator.enabled = true;
        }
    }
}
