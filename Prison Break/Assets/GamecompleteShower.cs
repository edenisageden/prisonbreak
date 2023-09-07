using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamecompleteShower : MonoBehaviour
{
    [SerializeField] private NextLevelBox nextLevelBox;
    [SerializeField] private float delay;

    private void Update()
    {
        if (nextLevelBox.isComplete)
        {
            StartCoroutine(GoToComplete());
        }
    }

    private IEnumerator GoToComplete()
    {
        PlayerPrefs.SetFloat("CompleteTime" + 10, 3f);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(14);
    }
}
