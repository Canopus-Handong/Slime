using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Element
{
    private void Awake() {
        this.nm = "Water";
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.FindWithTag("Player");
    }
    public override void useElement()
    {
        if(isActive) {
            Debug.Log("Water already active");
            return;
        }
        //dash reset on defeat
        Debug.Log("Water");
        isActive = true;
        GM.hasWater = true;
        GM.UpdatePlayerStatus();
    }

    public override void useElementTrace()
    {
        //reduce dash cd
        Debug.Log("Water Trace");
        GM.dashCoolTime -= 0.5f;
        if(GM.dashCoolTime < 1f) GM.dashCoolTime = 1f;
        GM.UpdatePlayerStatus();

    }
}
