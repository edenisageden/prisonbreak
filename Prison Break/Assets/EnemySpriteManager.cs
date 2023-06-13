using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteManager : MonoBehaviour
{
    [SerializeField] private EnemyShoot enemyShoot;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite fistSprite;

    private void Update()
    {
        if (enemyShoot.weapon != null) spriteRenderer.sprite = enemyShoot.weapon.enemySprite;
        else spriteRenderer.sprite = fistSprite;
    }
}
