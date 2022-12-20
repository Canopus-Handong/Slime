using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove2 : MonoBehaviour
{
    Rigidbody2D rigid;
    public Transform target;

    [Header("추격 속도")]
    [SerializeField] [Range(1f, 4f)] float moveSpeed = 3f;

    [Header("근접 거리")]
    [SerializeField] [Range(1f, 4f)] float moveDistance = 1f;

    bool follow = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FollwTarget();
    }

    void FollwTarget()
    {
        if(Vector2.Distance(transform.position, target.position) > moveDistance && follow)
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        else
            rigid.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        follow = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        follow = false;
    }
}
