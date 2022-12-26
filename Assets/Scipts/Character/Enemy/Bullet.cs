using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform playerPos;
    Vector2 dir;
    public float speed;
    public int damage;

    public LayerMask layer;
    void Start()
    {
        playerPos = GameObject.Find("Slime").GetComponent<Transform>();
        dir = playerPos.position - transform.position;

        Invoke("DestroyBullet", 3);

    }

    void Update()
    {

        if (dir.x < 0)
        {
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, 0, layer);
        if (ray.collider != null)
        {
            Destroy(gameObject);
            if (ray.collider.tag == "Player")
            {
                ray.collider.GetComponent<PlayerController>().playerDamaged(damage);
            }
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
