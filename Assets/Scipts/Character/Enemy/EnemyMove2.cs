using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove2 : MonoBehaviour
{
    public GameObject Enemyscript;
    public GameObject Detectzonescript;
    public GameObject Slimescript;
    public GameObject Platformscript;
    Rigidbody2D rigid;
    public Collider2D detectzone;
    public int enemyMove = 0;
    SpriteRenderer spriteRenderer;

    public bool follow = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        detectzone = Detectzonescript.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(Enemyscript.GetComponent<Collider2D>(), Platformscript.GetComponent<Collider2D>(), true);
    }

    void Update()
    {
        FollwTarget();
    }

    void FixedUpdate()
    {
        SelectMoving();

        //Check Platform
        Vector2 frontVec = new Vector2(rigid.position.x + enemyMove * 0.5f, rigid.position.y);
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));

        //If there is no platform, stop
        if (rayHit.collider == null) {
            enemyMove = 0;
        }

        //If monster turn back, turn image
        if (enemyMove != 0){
            spriteRenderer.flipX = enemyMove == 1;
        }
    }

    void SelectMoving()
    {
        //If no HP, stop
        if (Enemyscript.GetComponent<Enemy>().health <= 0)
        {
            enemyMove = 0;
            return;
        }
        else if ((Slimescript.GetComponent<Transform>().position.x - Enemyscript.GetComponent<Transform>().position.x) < 0)
        {
            enemyMove = -1;
            return;
        }
        else if ((Slimescript.GetComponent<Transform>().position.x - Enemyscript.GetComponent<Transform>().position.x) > 0)
        {
            enemyMove = 1;
            return;
        }
    }

    void FollwTarget()
    {
        if(follow)
        {
            rigid.velocity = new Vector2(enemyMove, rigid.velocity.y);
        }
        
        else
            rigid.velocity = Vector2.zero;
    }

    private void OnTriggerStay2D(Collider2D detect)
    {
        if (detect.tag == "Player")
            follow = true;
    }

    private void OnTriggerExit2D(Collider2D detect)
    {
        if (detect.tag == "Player")
            follow = false;
    }
}
