using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealEnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    int Direction = -1;
    public int maxHealth = 100;
    int currentHealth;
    SpriteRenderer _renderer;
    Animator anim;
    public GameObject prefab;
    public Transform _transform;
    public float right;
    public float left;
    private Collider2D collider2d;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = this.GetComponentInChildren<SpriteRenderer>();
        currentHealth = maxHealth;
        anim = this.GetComponentInChildren<Animator>();
        collider2d = this.GetComponent<Collider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigidbody2D = this.GetComponent<Rigidbody2D>();
        switch (Direction)
        {
            case -1:
                if (this.transform.position.x > left)
                {
                    rigidbody2D.velocity = new Vector2(-3, 0);
                    _renderer.flipX = true;
                }
                else
                {
                    Direction = 1;
                }
                break;
            case 1:
                if (this.transform.position.x < right)
                {
                    rigidbody2D.velocity = new Vector2(3, 0);
                    _renderer.flipX = false;
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Stone2")
        {
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
        WolfScript.killCounter++;
        StartCoroutine(Delay1sec());
        
    }

    IEnumerator Delay1sec()
    {
        while (true)
        {
            collider2d.enabled = false;
            anim.SetTrigger("EnemyDie");
            yield return new WaitForSeconds(1);
            Destroy(this.gameObject);
        }
    }

}
