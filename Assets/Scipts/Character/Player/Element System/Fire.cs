using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Element
{
    public override void useElement()
    {
        Debug.Log("Fire");
    }

    public override void useElementTrace()
    {
        Debug.Log("Fire Trace");
    }
}
