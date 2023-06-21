using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class LevelMenuManager : MonoBehaviour
{
    [SerializeField] private LevelInfo[] levelInfoList;
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
        InitializeLevelStatusImageDict();
        InitializeLevelMenu();
    }
    private void InitializeLevelStatusImageDict()
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
    private void InitializeLevelMenu()
    {
        for (int i = 0; i < levelInfoList.Length; i++)
        {
            levelInfoList[i].levelButton.GetComponent<Image>().sprite = levelStatusImageDict[GetLevelStatus(i + 1)];
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
                if (PlayerPrefs.GetFloat("CompleteTime" + level) <= levelInfoList[level - 1].GoldTime) return LevelStatus.Gold;
                else if (PlayerPrefs.GetFloat("CompleteTime" + level) <= levelInfoList[level - 1].SilverTime) return LevelStatus.Silver;
                else return LevelStatus.Bronze;
            }
            else return LevelStatus.Incomplete;
        }
        else return LevelStatus.Locked;
    }
}


