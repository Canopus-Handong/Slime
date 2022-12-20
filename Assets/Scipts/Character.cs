using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    float h;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D capsuleCollider;

    [SerializeField] private LayerMask layerMask;
    public float Speed;
    public int maxHealth = 10;
    public int currentHealth;
    public int dashDamage=2;
    public bool isFacingRight = true;

    private bool canDash = true;
    private bool isDashing;
    private float dashPower=12f;
    private float dashTime=0.2f;
    private float dashCoolTime=1f;
    [SerializeField] private TrailRenderer tr;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        currentHealth = maxHealth;
    }
    void Update()
    {
        if(isDashing){
            return;
        }
        h = Input.GetAxisRaw("Horizontal");
        if(IsGrounded() && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        if(currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash){
            StartCoroutine(Dash());
            currentHealth--;
        }
    }

    void FixedUpdate()
    {
        if(isDashing){
            return;
        }
        rigid.velocity = new Vector2(h * Speed, rigid.velocity.y);
        Flip();
    }

    private bool IsGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0f, Vector2.down, .1f, layerMask);
        return raycastHit.collider != null;
    }
    private void Flip(){
        if(h>0 && !isFacingRight || h<0 && isFacingRight){
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
    void Jump()
    {
        rigid.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
    }
    public void Eat(){
        currentHealth += 4;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            if(isDashing){
                other.gameObject.GetComponent<Enemy>().TakeDamage(dashDamage);
                if(other.gameObject.GetComponent<Enemy>().health<=0){
                Eat();
                Destroy(other.gameObject);
                }
            }
            else{
                if(other.gameObject.GetComponent<Enemy>().health<=0){
                    Eat();
                    Destroy(other.gameObject);
                }
                else{
                    currentHealth--;
                }
            }
        } 
    }
    private IEnumerator Dash(){
        canDash = false;
        isDashing = true;
        float originalGravity = rigid.gravityScale;
        rigid.gravityScale = 0f;
        rigid.velocity = new Vector2(transform.localScale.x * dashPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        rigid.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCoolTime);
        canDash = true;
    }
}
