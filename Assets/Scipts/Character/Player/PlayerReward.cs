using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerReward : MonoBehaviour
{
    public GameObject[] rewardscript;
    public int enemyCount;

    private bool isHealroom = true;
    
    void Start()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "HealRoom")
           isHealroom = false;
        else
           isHealroom = true;

        for (int i = 0; i < rewardscript.Length; i++)
            rewardscript[i].SetActive(false);
        
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = obj.Length;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemyCount <= 0 && !isHealroom)
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

        if (isHealroom)
        {
            for (int i = 0; i < rewardscript.Length; i++)
                rewardscript[i].SetActive(true);

            if (rewardscript[0].GetComponent<wellReward>().getReward)
            {
                rewardscript[0].SetActive(false);
                rewardscript[1].SetActive(false);
            }
            if (rewardscript[1].GetComponent<treasureReward>().getReward)
            {
                rewardscript[0].SetActive(false);

                Color tmp = rewardscript[1].GetComponent<SpriteRenderer>().color;
                tmp.a = 0f;
                rewardscript[1].GetComponent<SpriteRenderer>().color = tmp;
                rewardscript[1].transform.position = new Vector3(rewardscript[1].transform.position.x, rewardscript[1].transform.position.y - 10, rewardscript[1].transform.position.z);
            }
        }
    }
}
