using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Rigidbody2D playerRB;
    public AudioClip audioClip;
    AudioSource audioSource;
    public Animator playerAnimator;

    public static float moveSpeed = 4f;
    public static float jumpSpeed = 350f;
    public float jumpFrequency = 0.1f;
    public float nextJumpTime = 0f;

    public Transform groundCheckPosition;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundCheckLayer;

    bool facingRight = true;

    public static bool isGrounded = false;

 


  
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        audioSource = this.GetComponent<AudioSource>();
        audioClip = this.GetComponent<AudioClip>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        HorizontalMove();
        OnGroundCheck();
        Climbing();
        if (playerRB.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
        else if (playerRB.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }
    }
    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
        playerAnimator.SetFloat("PlayerSpeed", Mathf.Abs(playerRB.velocity.x));
        if (Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }
    }

    void FlipFace()
    {
       
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;

    }


    void Jump()
    {
        playerRB.AddForce(new Vector2(0, jumpSpeed));
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        playerAnimator.SetBool("isGrounded", isGrounded);
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
            yield return new WaitForSeconds(0.3f);
            other.GetComponent<Collider2D>().enabled = true;
        }
    }

    void PlayCheckAnimation()
    {
        playerAnimator.SetTrigger("CheckTrigger");
    }
    void Climbing()
    {
        if (Ladder.climb==true)
        {
            playerAnimator.SetBool("climb",Ladder.climb);
        }
        else
        {
            playerAnimator.SetBool("climb", Ladder.climb);
        }
        
    }
    public void PlayWalkSound(){
        if (!audioSource.isPlaying)
        {audioSource.Play();}
    }
}
