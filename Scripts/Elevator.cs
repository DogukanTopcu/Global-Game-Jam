using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Elevator : MonoBehaviour
{
    bool isDown = true;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            if (isDown)
            {
                this.gameObject.transform.DOLocalMoveY(10f, 3f);
                if (this.gameObject.transform.localPosition.y == 10f)
                {
                    isDown = false;
                }

            }
            else if (!isDown)
            {
                this.gameObject.transform.DOLocalMoveY(3.11f, 3f);
                if (this.gameObject.transform.localPosition.y == 3.11f)
                {
                    isDown = true;
                }
                
            }

        }
    }
}
