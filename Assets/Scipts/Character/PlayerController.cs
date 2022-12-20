using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    
    public GameManager GM;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D capsuleCollider;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private TrailRenderer tr;
    float h;
    private float speed;
    private int maxHealth;
    private int currentHealth;
    private int dashDamage;
    private bool isFacingRight = true;
    private bool canDash = true;
    private bool isDashing;
    private float dashPower;
    private float dashTime;
    private float dashCoolTime;
    private bool jumped = false;

    public void setPlayerDash(float dashPower, float dashDmg, float dashTime, float dashCoolTime){
        this.dashPower = dashPower;
        this.dashTime = dashTime;
        this.dashCoolTime = dashCoolTime;
    }
    /*may add more variables in the future*/
    public void setPlayerMovementStats(float speed){
        this.speed = speed;
    }

    public void setPlayerHealth(int maxHealth, int currentHealth){
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth;
    }
    private void Awake() {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        currentHealth = maxHealth;
    }

    private void Update() {
        Move();
    }


    //all movement related scrpits
/* 
//  Move by moving left and right
    private void Move(){
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
        rigid.velocity = new Vector2(h * speed, rigid.velocity.y);
        Flip();
    }
*/

//  Move by jumping left and right
    private void Move(){
        if(isDashing){
            return;
        }
        h = Input.GetAxisRaw("Horizontal");
        if(IsGrounded() && Input.GetKeyDown(KeyCode.UpArrow))
        {
            JumpMove(new Vector2(h*4,Vector2.up.y * 15));
            if(!jumped){
                rigid.velocity = Vector2.zero;
            }

        }
        if(currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash){
            StartCoroutine(Dash());
            currentHealth--;
        }
        Flip();
    }

    private void JumpMove(Vector2 force){
        rigid.AddForce(force, ForceMode2D.Impulse);
        jumped = !jumped;
    }
    private bool IsGrounded(){
        return Physics2D.OverlapCircle(new Vector2(transform.position.x,transform.position.y-0.6f),0.2f,layerMask);
    }

    private void Flip(){
        if(h>0 && !isFacingRight || h<0 && isFacingRight){
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1;
            transform.localScale = localScale;
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
        rigid.velocity = Vector2.zero;
        tr.emitting = false;
        rigid.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCoolTime);
        canDash = true;
    }

    void Jump()
    {
        rigid.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
    }



    public void Eat(){
        currentHealth += 4;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Platform" && jumped){
            rigid.velocity = Vector2.zero;
            jumped = !jumped;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
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
}
