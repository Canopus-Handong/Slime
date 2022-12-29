using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSJ : MonoBehaviour
{
    public int attackValue;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<Enemy>().TakeDamage(attackValue);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<Enemy>().TakeDamage(attackValue);
            Destroy(this.gameObject);
        }
        else if(other.gameObject.layer == 7){
            Destroy(this.gameObject);
        }
    }
}
