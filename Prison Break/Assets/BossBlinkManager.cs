using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBlinkManager : MonoBehaviour
{
    //Blink/flash white on player damaged

    [SerializeField] SpriteRenderer bossSprite;
    [SerializeField] Material blinkMaterial, defaultMaterial;
    [SerializeField] float blinkTime;

    private void Awake()
    {
        //Subscribes blink to damage delegate
        BossLogic.OnDamaged += CallBlinkWhite;
    }

    private void OnDestroy()
    {
        BossLogic.OnDamaged -= CallBlinkWhite;
    }

    void CallBlinkWhite()
    {
        StartCoroutine("BlinkWhite");
    }

    IEnumerator BlinkWhite()
    {
        bossSprite.material = blinkMaterial;
        yield return new WaitForSecondsRealtime(blinkTime);
        bossSprite.material = defaultMaterial;
    }
}
