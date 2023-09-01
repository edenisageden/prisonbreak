using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitpauseManager : MonoBehaviour
{
    [SerializeField] float pauseTime;

    private void Awake()
    {
        PlayerDeath.OnPlayerDeath += CallHitStop;
        EnemyLogic.OnEnemyDeath += CallHitStop;
        BossLogic.OnDamaged += CallHitStop;
    }
    private void OnDestroy()
    {
        PlayerDeath.OnPlayerDeath -= CallHitStop;
        EnemyLogic.OnEnemyDeath -= CallHitStop;
        BossLogic.OnDamaged -= CallHitStop;
    }

    public void CallHitStop()
    {
        print("Hit stop called");
        StartCoroutine(HitStop());
    }

    IEnumerator HitStop()
    {
        print("Hit stop started");
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(pauseTime);

        Time.timeScale = 1f;
    }
}
