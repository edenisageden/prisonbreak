using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Info", menuName = "Misc/Level Info")]
public class LevelInfoSO : ScriptableObject
{
    public int level;
    public float goldTime;
    public float silverTime;
    public bool isBoss;
}
