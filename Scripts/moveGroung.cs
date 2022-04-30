using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class moveGroung : MonoBehaviour
{
    bool isRight = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            if (isRight)
            {
                this.gameObject.transform.DOLocalMoveX(113f, 3f);
                
                if (this.gameObject.transform.localPosition.x == 113f)
                {
                    isRight = false;
                }

            }
            else if (!isRight)
            {
                this.gameObject.transform.DOLocalMoveX(118f, 3f);
                if (this.gameObject.transform.localPosition.x == 118f)
                {
                    isRight = true;
                }
                
            }

        }
    }
}
