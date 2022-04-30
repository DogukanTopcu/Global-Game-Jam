using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFlower : MonoBehaviour
{
    public static int flowerCounter;
    public move moveScript;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            if (move.isGrounded)
            {
                Physics2D.IgnoreCollision(other, GetComponent<Collider2D>());
                moveScript.playerAnimator.SetTrigger("CheckTrigger");
                Destroy(this.gameObject);
                flowerCounter++;
                print(flowerCounter);
            }
            
        }
        
    }
}
