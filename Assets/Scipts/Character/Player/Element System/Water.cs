using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Element
{
    private void Awake() {
        this.nm = "Water";
    }
    public override void useElement()
    {
        //dash reset on defeat
        Debug.Log("Water");
    }

    public override void useElementTrace()
    {
        //reduce dash cd
        Debug.Log("Water Trace");
    }
}
