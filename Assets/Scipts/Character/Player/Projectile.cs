using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float distance;
    public int damage;
    public LayerMask isLayer;
    public bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        isRight=GameObject.Find("Slime").GetComponent<PlayerController>().isFacingRight;
        Invoke("DestroyProjectile",3);
    }

    // Update is called once per frame
    void Update()
    {   
        if(isRight)
            transform.Translate(transform.right * speed * Time.deltaTime);
        else
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);

        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);

        if(ray.collider != null)
        {
            
            if(ray.collider.tag=="Enemy")
            {
                ray.collider.GetComponent<Enemy>().TakeDamage(damage);
            }   
            
            DestroyProjectile();
            
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
