using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kopru : MonoBehaviour
{
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 1;

        }
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag=="Player")
    //    {
    //        rb.bodyType = RigidbodyType2D.Dynamic;
    //        rb.gravityScale = 1;

    //    }
    //}
}
