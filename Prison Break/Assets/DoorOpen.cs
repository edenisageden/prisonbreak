using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private DoorLogic doorLogic;
    [SerializeField] private bool clockwise;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            doorLogic.OpenDoor(clockwise);
        }
    }
}
