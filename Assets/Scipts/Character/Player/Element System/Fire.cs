using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Element
{
    private void Awake() {
        this.nm = "Fire";
    }
    public override void useElement()
    {
        //dmg multiplier x2
        Debug.Log("Fire");
    }

    public override void useElementTrace()
    {
        //increase dmg
        Debug.Log("Fire Trace");
    }
}
