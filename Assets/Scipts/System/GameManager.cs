using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //player related variables
    public GameObject player;
    public int currentPlayerHealth = 0;
    public int maxPlayerHealth = 10;
    public int dashDmg = 2;
    public float dashPower=12f;
    public float dashTime=0.2f;
    public float dashCoolTime=1f;
    public float speed = 5f;

    //enemy related variables

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    public void addPlayerMaxHealth(int health){
        maxPlayerHealth += health;
    }

    private void Update() {
        if(!player){
            player = GameObject.FindGameObjectWithTag("Player");
            if(player){
                if(currentPlayerHealth == 0) currentPlayerHealth = maxPlayerHealth;
                PlayerController pc = player.GetComponent<PlayerController>();
                pc.setPlayerDash(dashPower,dashDmg,dashTime,dashCoolTime);
                pc.setPlayerMovementStats(speed);
                pc.setPlayerHealth(maxPlayerHealth,currentPlayerHealth);
            }

        }
    }

}
