using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : Element
{
    private void Awake() {
        this.nm = "Earth";
    }
    public override void useElement()
    {
        //increase max hp with kills
        Debug.Log("Earth");
    }

    public override void useElementTrace()
    {
        //increase small max hp
        Debug.Log("Earth Trace");
    }
}
