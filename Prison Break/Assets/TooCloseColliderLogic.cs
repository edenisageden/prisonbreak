using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooCloseColliderLogic : MonoBehaviour
{
    public bool isTooClose = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnvironmentCollider")
        {
            isTooClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "EnvironmentCollider") isTooClose = false;
    }
}
