using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(health<=0){
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            damage=0;
        }
    }
}   