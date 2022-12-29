using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : Element
{
    private void Awake() {
        this.nm = "Earth";
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.FindWithTag("Player");
    }
    public override void useElement()
    {
        if(isActive) {
            Debug.Log("Earth already active");
            return;
        }
        //increase max hp with kills
        Debug.Log("Earth");
    }

    public override void useElementTrace()
    {
        //increase small max hp
        Debug.Log("Earth Trace");
    }
}
