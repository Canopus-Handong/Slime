using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float attackRange = 1.5f;
    public int attackDamage = 10;
    public float attackRate = 1f;
    public LayerMask playerLayer;

    private float lastAttackTime;

    void Update()
    {
        if (Time.time >= lastAttackTime + attackRate)
        {
            if (IsPlayerInRange())
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
    }

    bool IsPlayerInRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, PlayerController.instance.transform.position);

        return distanceToPlayer <= attackRange;
    }

    void Attack()
    {
        PlayerController.instance.TakeDamage(attackDamage);
    }
}