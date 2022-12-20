using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //player related variables
    public GameObject player;
    public int currentHealth = 0;
    public int maxHealth = 10;
    public int dashDmg = 2;
    public float dashPower=12f;
    public float dashTime=0.2f;
    public float dashCoolTime=1f;
    public float speed = 5f;

    //enemy related variables
    public GameObject[] enemies;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update() {
        
        if(currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
        if(!player){
            player = GameObject.FindGameObjectWithTag("Player");
            if(player){
                if(currentHealth == 0) currentHealth = maxHealth;
                PlayerController pc = player.GetComponent<PlayerController>();
                pc.setPlayerDash(dashPower,dashDmg,dashTime,dashCoolTime);
                pc.setPlayerMovementStats(speed);
            }

        }
    }

}
