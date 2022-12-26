using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    private int dashDamage;
    public bool isFacingRight = true;
    private bool canDash = true;
    private bool isDashing;
    private float dashPower;
    private float dashTime;
    private float dashCoolTime;
    public bool canJump = true;

    /*may add more variables in the future*/
    //Dash status
    public void setPlayerDash(float dashPower, int dashDmg, float dashTime, float dashCoolTime){
        this.dashPower = dashPower;
        this.dashTime = dashTime;
        this.dashCoolTime = dashCoolTime;
        this.dashDamage = dashDmg;
    }
    //Player moving speed
    public void setPlayerMovementStats(float speed){
        this.speed = speed;
    }

    private void Awake() {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        //If user is dashing, don't move by keyboard
        if(isDashing){
            return;
        }
        h = Input.GetAxisRaw("Horizontal");
        //If the user is in contact with the floor and canjump with the up button, jump.
        if(IsGrounded() && Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            StartCoroutine(Jump());
        }
        //If the user candash with the shift button, dash.
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash){
            StartCoroutine(Dash());
            GM.currentHealth--;
        }
    }

    void FixedUpdate()
    {
        //If user is dashing, don't move by keyboard
        //If user turn back, turn back the direction of movement and the character
        if(isDashing){
            return;
        }
        rigid.velocity = new Vector2(h * speed, rigid.velocity.y);
        Flip();
    }
    //If the user is in contact with the platform layer, isgrounded state
    private bool IsGrounded(){
        return Physics2D.OverlapCircle(new Vector2(transform.position.x,transform.position.y-0.6f),0.2f,layerMask);
    }
    //If user turn back, turn back
    private void Flip(){
        if(h>0 && !isFacingRight || h<0 && isFacingRight){
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
    //Jump status(cooltime, height)
    private IEnumerator Jump()
    {
        canJump = false;
        rigid.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        canJump = true;
    }
    //If eat monster, heal.
    public void Eat(){
        GM.currentHealth += 4;
    }
    //유저가 몬스터와 닿았을때, 상황별로 이벤트 작동
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
                    GM.currentHealth--;
                }
            }
        } 
    }
    //Dash status(gravity, dash distance, cooltime)
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
