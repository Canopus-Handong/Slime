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
    public bool isActive = false;
    public string nm;
    public int numTrace = 0 ;
    private GameManager GM;
    // Start is called before the first frame update
    void Awake(){
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //unique effects of element
    public abstract void useElement();
    public abstract void useElementTrace();

    public void increaseTrace(){
        numTrace++;
    }
}
