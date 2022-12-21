using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAndFall : MonoBehaviour
{
    Rigidbody2D rigid;
    Collider2D playerCollider, platformCollider;
    public GameObject Platformscript;
    public bool fallGround;
    float moveX;

    void IgnoreTure()
    {
        Physics2D.IgnoreCollision(playerCollider, platformCollider, true);
    }

    void IgnoreFalse()
    {
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }

    IEnumerator LayerOpenClose()
    {
        fallGround = true;
        IgnoreTure();
        yield return new WaitForSeconds(0.2f);
        IgnoreFalse();
        fallGround = false;
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        platformCollider = Platformscript.GetComponent<Collider2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
            StartCoroutine(LayerOpenClose());
        
        if (rigid.velocity.y > 0)
            IgnoreTure();
        else if (rigid.velocity.y <= 0 && !fallGround)
            IgnoreFalse();
    }
}
