using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Element
{
    private void Awake() {
        this.nm = "Fire";
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.FindWithTag("Player");
    }
    public override void useElement()
    {
        if(isActive) {
            Debug.Log("Fire already active");
            return;
        }
        Debug.Log("Fire");
        //dmg multiplier x2
        GM.attackDmg *= 2;
        isActive = true;
        GM.UpdatePlayerStatus();
    }

    public override void useElementTrace()
    {
        //increase dmg
        Debug.Log("Fire Trace");
        if(isActive){
            GM.attackDmg += 2;
        } else {
            GM.attackDmg += 1;
        }
        GM.UpdatePlayerStatus();
    }
}
