using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    public string ignoreLayer; 
    [SerializeField] private float bulletLifetime;

    private void Start()
    {
        Destroy(gameObject, bulletLifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool hasCollided = collision.gameObject.layer != LayerMask.NameToLayer(ignoreLayer) && !collision.isTrigger;
        IKillable killable = collision.gameObject.GetComponent<IKillable>();

        if (hasCollided)
        {
            if (killable != null) killable.Kill();
            Destroy(gameObject);
        }
    }
}
