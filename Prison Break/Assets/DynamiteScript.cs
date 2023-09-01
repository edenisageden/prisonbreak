using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DynamiteScript : MonoBehaviour
{
    [SerializeField] private float dynamiteExplosionTimeMin, DynamiteExplosionTimeMax;
    [SerializeField] private Collider2D radius;
    private Collider2D playerCol;
    [SerializeField] private Animator animator;
    public static event Action OnDynamiteExplode = delegate { };

    private void Start()
    {
        StartCoroutine(DynamiteExplosion());
    }

    private IEnumerator DynamiteExplosion()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(dynamiteExplosionTimeMin, DynamiteExplosionTimeMax));
        animator.SetTrigger("OnExplode");
        OnDynamiteExplode?.Invoke();
        if (FindAnyObjectByType<PlayerController>())
        {
            playerCol = FindAnyObjectByType<PlayerController>().GetComponent<Collider2D>();
            if (radius.IsTouching(playerCol))
            {
                playerCol.GetComponent<PlayerDeath>().Kill();
            }
        }
        yield return new WaitForSeconds(0.17f);
        Destroy(gameObject);
    }
}
