using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasureReward : MonoBehaviour
{
    public bool getReward = false;
    public GameObject[] rewardscript;

    void Start()
    {
        for (int i = 0; i < rewardscript.Length; i++)
            rewardscript[i].SetActive(false);
    }

    void FixedUpdate()
    {
        for (int j = 0; j < rewardscript.Length; j++)
            {
                if (rewardscript[j].GetComponent<MapClearReward>().getReward)
                {
                    for (int k = 0; k < rewardscript.Length; k++)
                        rewardscript[k].SetActive(false);
                }
            }
    }

    private void OnTriggerStay2D(Collider2D detect)
    {
        if (detect.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                for (int i = 0; i < rewardscript.Length; i++)
                    rewardscript[i].SetActive(true);
                Debug.Log("보물을 선택하세요.");
                getReward = true;
            }
        }      
    }
}
