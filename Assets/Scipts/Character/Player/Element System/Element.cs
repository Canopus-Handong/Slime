using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementException : Exception
{
    public ElementException(){}
    public ElementException(string message) : base(message){}
    public ElementException(string message, Exception inner) : base(message, inner){}
}
public abstract class Element : MonoBehaviour
{
    private GameObject GM;
    // Start is called before the first frame update
    void Awake(){
        //GM = this.gameObject.GetComponent<GameManager>();
    }

    public abstract void useElement();
    public abstract void useElementTrace();
}
