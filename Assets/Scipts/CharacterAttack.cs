using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public GameObject jelly;
    public Transform pos;
    public float coolTime;
    private float curTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(curTime<=0){
            if(Input.GetKeyDown(KeyCode.Space)){
               GetComponent<Character>().currentHealth--;
               Instantiate(jelly,pos.position,transform.rotation);
               curTime = coolTime;
            }
         }
         else{
              curTime -= Time.deltaTime;
       }
    }
}
