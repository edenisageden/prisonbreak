using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] GameObject hitEffect;

    private void Start()
    {
        BulletLogic.OnObstacleHit += SpawnHitEffect;
    }

    private void OnDestroy()
    {
        BulletLogic.OnObstacleHit -= SpawnHitEffect;
    }

    public void SpawnHitEffect(Vector3 spawnLocation, Quaternion rotation)
    {
        GameObject newHitEffect = Instantiate(hitEffect, spawnLocation, rotation);
    }
}
