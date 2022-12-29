using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wellReward : MonoBehaviour
{
    public bool getReward = false;
    public GameManager GM;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerStay2D(Collider2D detect)
    {
        if (detect.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log(gameObject.name + " 보상을 획득하였습니다.");
                getReward = true;
                GM.currentHealth += 4;
            }
        }      
    }
}
