using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int enemyMove;
    public GameObject Enemyscript;
    public float nextMovingTime;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Delay function(5 sec)
        Invoke("SelectMoving", 5);
        enemyMove = -1;
    }

    void FixedUpdate()
    {
        //If no HP, stop
        if (Enemyscript.GetComponent<Enemy>().health <= 0 && enemyMove != 0){
            SelectMoving();
        }

        //Move
        rigid.velocity = new Vector2(enemyMove, rigid.velocity.y);

        //Check Platform
        Vector2 frontVec = new Vector2(rigid.position.x + enemyMove * 0.5f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
        //If there is no platform, turn back
        if (rayHit.collider == null) {
            Turn();
        }
    }

    void SelectMoving()
    {
        if (Enemyscript.GetComponent<Enemy>().health <= 0){
            enemyMove = 0;
        }
        else {
            enemyMove = Random.Range(-1,2);
            nextMovingTime = Random.Range(2f, 5f);
        }

        //Flip sprite
        if (enemyMove != 0){
            spriteRenderer.flipX = enemyMove == 1;
        }

        Invoke("SelectMoving", nextMovingTime);
    }

    void Turn()
    {
        enemyMove = enemyMove * -1;
        spriteRenderer.flipX = enemyMove == 1;
        CancelInvoke();
        Invoke("SelectMoving", 5);
    }
}
