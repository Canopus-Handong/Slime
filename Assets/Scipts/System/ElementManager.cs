using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementManager : MonoBehaviour
{   
    public static ElementManager instance;

    public List<Element> elements = new List<Element>();

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of ElementManager found!");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void AddElement(Element element)
    {
        elements.Add(element);
    }

    //debug area

    public string debElement;
    public string debTrace;
    public bool debug = false;

    private void Update() {
        if(debug){
            debug = !debug;
            foreach(Element e in elements){
                if(e.nm == debElement){
                    e.useElement();
                }
                if(e.nm == debTrace){
                    e.useElementTrace();
                    e.increaseTrace();
                }
            }
        }
    }
}
