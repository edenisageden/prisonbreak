using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour, IKillable
{
    public void Kill()
    {
        print("Player death");
    }
}
