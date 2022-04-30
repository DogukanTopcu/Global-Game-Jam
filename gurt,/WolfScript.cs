using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WolfScript : MonoBehaviour
{
    public float stoneAttackRange = 0.1f;
    public int forceY = 40;
    public int stonesLeft = 0;
    public GameObject enemy;
    public GameObject Stone;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    public float moveSpeed = 4;
    Rigidbody2D rb;
    public bool isGrounded = false;
    public GameObject groundCheckPosition;
    public float groundCheckRadius = 0.1f;
    public static float jumpSpeed = 400f;
    public float jumpFrequency = 0.1f;
    public float nextJumpTime = 0f;
    public LayerMask groundCheckLayer;
    Animator animator;
    SpriteRenderer _renderer;
    public Text killCounterText;

    public static int killCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        killCounter = 0;
        _renderer = GetComponent<SpriteRenderer>();
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxisRaw("Horizontal");
        CheckFlip(xDirection);
        HorizontalMove();
        OnGroundCheck();
        killCounterText.text = killCounter.ToString();
        if (Input.GetKeyDown(KeyCode.F))
        {
            ThrowStone();
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else{
            animator.SetBool("IsWalking", false);
        }
        if (isGrounded)
        {
            animator.SetBool("IsGrounded", isGrounded);
        }

        else {
            animator.SetBool("IsGrounded", isGrounded);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if(killCounter == 13)
        {
            SceneManager.LoadScene(2);
        }
    }
    void Attack()
    {
        animator.SetTrigger("IsKilling");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<RealEnemyScript>().TakeDamage(attackDamage);
        }
    }
    void HorizontalMove()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);

        if (Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }
    }
    void ThrowStone()
    {
        if (stonesLeft > 0)
        { 
            animator.SetTrigger("IsKilling");
            GameObject newStone = Instantiate(Stone, this.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            Rigidbody2D _rigidBody2D = newStone.GetComponent<Rigidbody2D>();
            _rigidBody2D.AddForce(new Vector2(-this.transform.localScale.x * 500, forceY));
            stonesLeft--;
        }
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.transform.position, groundCheckRadius, groundCheckLayer);
    }
    void CheckFlip(float flipDirection)
    {
        if (flipDirection > 0)
        {
            this.transform.localScale = new Vector3(-1,1,1);
        }
        if(flipDirection < 0)
        {
            this.transform.localScale = new Vector3(1,1,1);
        }
    }
    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpSpeed));
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Stone")
        {
            stonesLeft++;
            Destroy(other.gameObject);
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "TransitiveGround")
        {
            if (Input.GetAxis("Vertical") < 0)
            {
                StartCoroutine(TransitiveJump());
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                StartCoroutine(TransitiveJump());
            }
        }

        IEnumerator TransitiveJump()
        {
            other.GetComponent<Collider2D>().enabled = false;
            yield return new WaitForSeconds(0.4f);
            other.GetComponent<Collider2D>().enabled = true;
        }
    }
}
