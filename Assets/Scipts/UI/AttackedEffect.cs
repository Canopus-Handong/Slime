using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackedEffect : MonoBehaviour
{
    public GameObject AttackEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.tag == "Enemy")
        {
            var clone = Instantiate(AttackEffect, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(clone, 0.5f);
        }
    }
}
