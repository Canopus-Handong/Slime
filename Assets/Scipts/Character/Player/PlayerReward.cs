using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReward : MonoBehaviour
{
    public GameObject[] rewardscript;
    public int enemyCount;
    
    void Start()
    {
        for (int i = 0; i < rewardscript.Length; i++)
            rewardscript[i].SetActive(false);
        
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = obj.Length;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemyCount <= 0)
        {
            for (int i = 0; i < rewardscript.Length; i++)
                rewardscript[i].SetActive(true);
            
            for (int j = 0; j < rewardscript.Length; j++)
            {
                if (rewardscript[j].GetComponent<MapClearReward>().getReward)
                {
                    for (int k = 0; k < rewardscript.Length; k++)
                        rewardscript[k].SetActive(false);
                }
            }
        }
    }
}
