using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapClearReward : MonoBehaviour
{
    public bool getReward = false;

    private void OnTriggerStay2D(Collider2D detect)
    {
        if (detect.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log(gameObject.name + " 보상을 획득하였습니다.");
                getReward = true;
            }
            
        }
            
    }
}
