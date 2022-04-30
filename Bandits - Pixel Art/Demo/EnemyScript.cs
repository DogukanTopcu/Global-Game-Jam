using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    int Direction = -1;
    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigidbody2D = this.GetComponent<Rigidbody2D>();
       switch (Direction)
       {
        case -1:
            if(this.transform.position.x > -2)
            {
                rigidbody2D.AddForce(new Vector2(-1, 0), ForceMode2D.Force);
            }
            else
            {
                Direction = 1;
            }
            break;
        case 1:
            if (this.transform.position.x < 0)
            {
                rigidbody2D.AddForce(new Vector2(1,0), ForceMode2D.Force);
            }
            else
            {
                Direction = -1;
            }
            break;
        default:
            print("Expected Status");
            break;
       }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Stone2") {
        TakeDamage(100); 
        Destroy(other.gameObject);
        }
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}