using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapClearReward : MonoBehaviour
{
    public int reward;

    private void OnTriggerStay2D(Collider2D detect)
    {
        if (detect.tag == "Player")
        {
            reward = Random.Range(1,13);
            Debug.Log(reward + "번 보상을 획득하였습니다.");
            Destroy(gameObject);
        }
            
    }
}
