using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class LevelMenuManager : MonoBehaviour
{
    [SerializeField] private Button[] buttonList;
    [SerializeField] private LevelInfoSO[] levelInfoSOList;
    [SerializeField] private Sprite bronzeButtonImage, silverButtonImage, goldButtonImage, incompleteButtonImage, lockedButtonImage;

    private Dictionary<LevelStatus, Sprite> levelStatusImageDict;

    private enum LevelStatus
    { 
        Bronze,
        Silver,
        Gold,
        Incomplete,
        Locked
    }
    private void Awake()
    {
        PlayerPrefs.SetInt("LevelUnlocked1", 1);
        InitializeDict();
        InitializeButtons();
    }
    private void InitializeDict()
    {
        levelStatusImageDict = new Dictionary<LevelStatus, Sprite>
        {
            {LevelStatus.Bronze, bronzeButtonImage},
            {LevelStatus.Silver, silverButtonImage},
            {LevelStatus.Gold, goldButtonImage},
            {LevelStatus.Incomplete, incompleteButtonImage},
            {LevelStatus.Locked, lockedButtonImage},
        };
    }
    private void InitializeButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponent<Image>().sprite = levelStatusImageDict[GetLevelStatus(i + 1)];
            if (GetLevelStatus(i + 1) == LevelStatus.Locked)
            {
                buttonList[i].GetComponentInChildren<TMP_Text>().text = null; 
            }
            else
            {
                buttonList[i].GetComponentInChildren<TMP_Text>().text = (i + 1).ToString();
            }
            Debug.Log("Level:" + i + 1 + " Status:" + GetLevelStatus(i + 1).ToString());
        }
    }
    private int LevelUnlocked(int level)
    {
        return PlayerPrefs.GetInt("LevelUnlocked" + level, 0);
    }
    private int LevelComplete(int level)
    {
        return PlayerPrefs.GetInt("LevelComplete" + level, 0);
    }
    private LevelStatus GetLevelStatus(int level)
    {
        if (LevelUnlocked(level) == 1)
        {
            if (LevelComplete(level) == 1)
            {
                if (PlayerPrefs.GetFloat("CompleteTime" + level) <= levelInfoSOList[level - 1].goldTime) return LevelStatus.Gold;
                else if (PlayerPrefs.GetFloat("CompleteTime" + level) <= levelInfoSOList[level - 1].silverTime) return LevelStatus.Silver;
                else return LevelStatus.Bronze;
            }
            else return LevelStatus.Incomplete;
        }
        else return LevelStatus.Locked;
    }
}


