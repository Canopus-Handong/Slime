using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
   public GameManager GM;
    public GameObject jelly;
    public Transform pos;
    public float coolTime;
    private float curTime;
    private void Awake() {
         GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       if(curTime<=0){
            if(Input.GetKeyDown(KeyCode.Space)){
               GM.currentPlayerHealth -= 1;
               Instantiate(jelly,pos.position,transform.rotation);
               curTime = coolTime;
            }
         }
         else{
              curTime -= Time.deltaTime;
       }
    }
}
