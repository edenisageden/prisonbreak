using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AmmoShowAndHide : MonoBehaviour
{
    [SerializeField] GameObject AmmoCounter;
    [SerializeField] GameObject TimeCounter;
    [SerializeField] GameObject Dialogue;
    [SerializeField] NextLevelBox NextLevelBox;
    [SerializeField] GameMenuManager gameMenuManager;
    [SerializeField] PlayerDeath playerDeath;
    [SerializeField] Dialogue dialogue;

    private void Update()
    {
        // If paused, hide ammo counter
        // If game complete, hide ammo counter
        // If died, hide ammo counter
        // Else, show ammo counter

        if (gameMenuManager.isPaused)
        {
            AmmoCounter.SetActive(false);
            TimeCounter.SetActive(false);
            Dialogue.SetActive(false);
        }
        else if (NextLevelBox.isCompleteFully)
        {
            AmmoCounter.SetActive(false);
            TimeCounter.SetActive(false);
            Dialogue.SetActive(false);
        }
        else if (playerDeath.isDead)
        {
            AmmoCounter.SetActive(false);
            TimeCounter.SetActive(false);
            Dialogue.SetActive(false);
        }
        else
        {
            AmmoCounter.SetActive(true);
            TimeCounter.SetActive(true);
            if (!dialogue.finishedDialogue) Dialogue.SetActive(true);
        }
    }
}
