using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;
    public int health;
    public GameObject enemyHP1;
    public GameObject enemyHP2;
    public GameObject enemyHP3;
    public Sprite[] HPbar;
    float onethirdHealth;
    // Start is called before the first frame update
    void Start()
    {
        onethirdHealth = health / 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(health<=0){
            GetComponent<SpriteRenderer>().color = Color.blue;
            GetComponent<BoxCollider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            //change layer to default
            gameObject.layer = 0;
        }
    }
    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            damage=0;
        }

        if (health <= onethirdHealth * 2)
        {
            enemyHP1.GetComponent<SpriteRenderer>().sprite = HPbar[0];
        }
        if (health <= onethirdHealth * 1)
        {
            enemyHP2.GetComponent<SpriteRenderer>().sprite = HPbar[1];
        }
        if (health <= 0)
        {
            enemyHP3.GetComponent<SpriteRenderer>().sprite = HPbar[2];
        }
    }

    private void OnTriggerEnter2D(Collider2D detect)
    {
        if (detect.gameObject.layer == 7)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
}   
