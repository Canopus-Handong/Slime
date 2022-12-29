using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeMove : MonoBehaviour
{
    public GameObject Enemyscript;
    public GameObject Slimescript;
    public GameObject Platformscript;
    Rigidbody2D rigid;
    public Collider2D detectzone;
    public float followSpeed = 2.0f;
    public float notfollowSpeed = 1.2f;
    public int enemyMove;
    SpriteRenderer spriteRenderer;

    public GameObject bullet;
    public float cool;

    private int frame;

    public bool follow = false;
    public bool notfollowButmove = false;

    private bool isAlive;


    void Awake()
    {
        frame = 0;
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Physics2D.IgnoreCollision(detectzone, Platformscript.GetComponent<Collider2D>(), true);
        isAlive = true;

        Invoke("Moving", 3);
    }

    void FixedUpdate()
    {

        FollwTarget();

        if (isAlive)
        {
            if (follow)
            {
                SelectMoving();
                if (frame % (cool * 50) == 0)
                {
                    Bullet();
                }
                frame++;
            }
            else
            {
                if (frame > 0)
                {
                    if (frame % (cool * 50) != 0)
                    {
                        frame++;
                    }
                }
            }
        }

        if (Enemyscript.GetComponent<Enemy>().health <= 0)
        {
            isAlive = false;
        }

        if (Enemyscript.GetComponent<Enemy>().health <= 0 && notfollowButmove)
        {
            enemyMove = 0;
            CancelInvoke();
        }
        //Check Platform
        Vector2 frontVec = new Vector2(rigid.position.x + enemyMove * 0.5f, rigid.position.y);
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));

        Vector2 frontVec2 = new Vector2(rigid.position.x + enemyMove * 0.5f, rigid.position.y + 0.5f);
        RaycastHit2D rayHit2 = Physics2D.Raycast(frontVec2, Vector3.down, 1, LayerMask.GetMask("Platform"));

        if (rayHit2.collider != null)
        {
            if (notfollowButmove)
            {
                enemyMove = enemyMove * -1;
                CancelInvoke();
                Invoke("Moving", 5);
            }
        }

        //If there is no platform, stop
        if (rayHit.collider == null)
        {
            if (!notfollowButmove)
                enemyMove = 0;
            if (notfollowButmove)
            {
                enemyMove = enemyMove * -1;
                CancelInvoke();
                Invoke("Moving", 5);
            }
        }

        //If monster turn back, turn image
        if (enemyMove != 0)
        {
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

    void Moving()
    {
        notfollowButmove = true;

        if (follow)
            return;
        if (Enemyscript.GetComponent<Enemy>().health <= 0)
        {
            enemyMove = 0;
            return;
        }
        else
        {
            enemyMove = Random.Range(-1, 2);

        }

        Invoke("Moving", 5);
    }

    void FollwTarget()
    {
        if (follow || notfollowButmove)
        {
            //Moving
            if (follow)
                rigid.velocity = new Vector2(enemyMove * followSpeed, rigid.velocity.y);
            else if (notfollowButmove)
                rigid.velocity = new Vector2(enemyMove * notfollowSpeed, rigid.velocity.y);
        }
        
        else
            rigid.velocity = Vector2.zero;
    }

    private void OnTriggerStay2D(Collider2D detect)
    {
        if (detect.tag == "Player")
        {
            follow = true;
            notfollowButmove = false;
            CancelInvoke();
        }
    }

    private void OnTriggerExit2D(Collider2D detect)
    {
        if (detect.tag == "Player")
        {
            follow = false;
            Invoke("Moving", 5);
        }
    }

    void Bullet()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}