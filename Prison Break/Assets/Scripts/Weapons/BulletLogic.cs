using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class BulletLogic : MonoBehaviour
{
    public string ignoreLayer; 
    [SerializeField] private float bulletLifetime;
    [SerializeField] private int damage;
    public static event Action <Vector3, Quaternion> OnObstacleHit = delegate { };
    public static event Action OnBulletCollision = delegate { };

    private void Start()
    {
        Destroy(gameObject, bulletLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool hasCollided = collision.gameObject.layer != LayerMask.NameToLayer(ignoreLayer);
        IKillable killable = collision.gameObject.GetComponent<IKillable>();
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();

        if (collision.gameObject.layer == LayerMask.NameToLayer("Environment")) OnObstacleHit?.Invoke(transform.position, transform.rotation);

        if (hasCollided)
        {
            OnBulletCollision?.Invoke();
            if (damagable != null) damagable.Damage(damage);
            else if (killable != null) killable.Kill();
            Destroy(gameObject);
        }
    }
}
