using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeAttack : MonoBehaviour
{
    public GameObject bullet;
    public float cool;

    void Start()
    {
        StartCoroutine(Bullet());
    }

    IEnumerator Bullet()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        yield return new WaitForSeconds(cool);
        StartCoroutine(Bullet());
    }
}