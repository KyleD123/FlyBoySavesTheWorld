using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public float speed = 50;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.AddForce((Vector2.left + Vector2.down) * speed * Time.fixedDeltaTime);
    }

    private void Update()
    {
        if (this.transform.position.x < -2.6f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.gameObject.transform.GetComponent<PlayerMovement>().Collected();
            Destroy(this.gameObject);
        }
    }
}
