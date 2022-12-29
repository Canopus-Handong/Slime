using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
   public GameManager GM;
    public GameObject jelly;
    public GameObject chargedjelly1;
    public GameObject chargedjelly2;
    public float chargeSpeed;

    private Transform pos;
    private float chargeTime;
    public float coolTime;
    private float curTime;

    private void Awake() {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        pos = GameObject.Find("jellyPos").GetComponent<Transform>();
        chargeTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
       if(curTime<=0)
       {
            if(Input.GetKeyDown(KeyCode.Space)){
                chargeTime = 0;
            }

            if (Input.GetKey(KeyCode.Space)&&chargeTime<1.5)
            {
                chargeTime += Time.deltaTime * chargeSpeed;
            }

            if (Input.GetKeyUp(KeyCode.Space)&&chargeTime>=0.75)
            {
                /*if (chargeTime >= 1.5)
                {
                    //Â÷Â¡ 2´Ü°è
                    GM.currentHealth -= 2;
                    Instantiate(chargedjelly2, pos.position, transform.rotation);
                    curTime = coolTime;
                }
                else
                {*/
                    //Â÷Â¡ 1´Ü°è
                    GM.currentHealth -= 2;
                    Instantiate(chargedjelly1, pos.position, transform.rotation);
                    curTime = coolTime;

                //}
            }
            else if (Input.GetKeyUp(KeyCode.Space) && chargeTime < 0.75)
            {
                GM.currentHealth -= 1;
                Instantiate(jelly, pos.position, transform.rotation);
                curTime = coolTime;
            }
         }
         else
         {
              curTime -= Time.deltaTime;
         }
    }
}
