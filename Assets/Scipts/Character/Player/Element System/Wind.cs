using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : Element
{
    private void Awake() {
        this.nm = "Wind";
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.FindWithTag("Player");
    }

    public override void useElement()
    {
        if(isActive) {
            Debug.Log("Wind already active");
            return;
        }
        //increase attack speed
        Debug.Log("Wind");
        player.GetComponent<CharacterAttack>().coolTime *= 0.5f;
    }

    public override void useElementTrace()
    {
        //increase projectile speed
        //tbd
        Debug.Log("Wind Trace");
    }
}
