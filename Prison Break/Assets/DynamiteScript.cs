using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteScript : MonoBehaviour
{
    [SerializeField] private float dynamiteExplosionTimeMin, DynamiteExplosionTimeMax;
    [SerializeField] private Collider2D radius;
    private Collider2D playerCol;
    [SerializeField] private Animator animator;

    private void Start()
    {
        StartCoroutine(DynamiteExplosion());
    }

    private IEnumerator DynamiteExplosion()
    {
        yield return new WaitForSeconds(Random.Range(dynamiteExplosionTimeMin, DynamiteExplosionTimeMax));
        animator.SetTrigger("OnExplode");
        playerCol = FindAnyObjectByType<PlayerController>().GetComponent<Collider2D>();
        if (radius.IsTouching(playerCol))
        {
            playerCol.GetComponentInParent<PlayerDeath>().Kill();
        }
        yield return new WaitForSeconds(0.17f);
        Destroy(gameObject);
    }
}
