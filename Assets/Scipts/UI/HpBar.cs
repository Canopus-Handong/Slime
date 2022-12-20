using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HpBar : MonoBehaviour{
    private GameManager GM;
    private GameObject player;
    
    [SerializeField]
    private Image hpBar;
    private float maxHp;
    private float currentHp;



    private void Awake() {
        hpBar = GetComponent<Image>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");

        maxHp = GM.maxPlayerHealth;
        currentHp = GM.currentPlayerHealth;
    }

    private void Update() {
        currentHp = GM.currentPlayerHealth;
        maxHp = GM.maxPlayerHealth;
        hpBar.fillAmount = currentHp/maxHp;
    }
}
 
 