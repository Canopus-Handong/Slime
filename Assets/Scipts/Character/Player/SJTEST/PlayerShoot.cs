using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject jellyPrefab;
    private GameObject jellyShot;
    public GameManager GM;

    private Transform pos;
    public float coolTime = 0.5f;
    private float curTime;
    public float bulletSpeed;

    private void Awake() {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        pos = GameObject.Find("jellyPos").GetComponent<Transform>();
        bulletSpeed = GM.bulletSpeed;
    }

    private void shoot(){
        jellyShot = Instantiate(jellyPrefab, transform.position, transform.rotation) as GameObject;
        jellyShot.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.localScale.x ,0)* bulletSpeed, ForceMode2D.Impulse);
        jellyShot.GetComponent<BulletSJ>().attackValue = GM.attackDmg;
        GM.currentHealth -= 1;
        curTime = coolTime;
    }

    private void Update() {
        if(curTime<=0 && Input.GetKeyDown(KeyCode.Space)){
            shoot();
        }
        else{
            curTime -= Time.deltaTime;
        }
    }
}
