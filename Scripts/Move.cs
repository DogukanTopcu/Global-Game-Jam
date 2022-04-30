using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpHeight = 10;
    private bool couldJump = false;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");   
        rb.AddForce(new Vector2(horizontalInput, 0), ForceMode2D.Force);
        if (Input.GetKeyDown(KeyCode.Space) && couldJump){
            rb.AddForce(Vector2.up * jumpHeight);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            couldJump = true;
            print("CouldJump");
        }
        else {
            couldJump = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
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
        

        IEnumerator TransitiveJump(){
            other.GetComponent<Collider2D>().enabled = false;
            yield return new WaitForSeconds(0.3f);
            other.GetComponent<Collider2D>().enabled = true;
        }
    }
}
