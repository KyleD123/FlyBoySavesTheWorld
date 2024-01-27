using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogJump : MonoBehaviour
{
    public float JumpPower = 35;
    private Rigidbody2D rb;
    private GameObject player;
    private Enemy e;

    public bool OnGround = true;
    public bool StartJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        e = this.GetComponent<Enemy>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(this.transform.position, player.transform.position) < 2.0f && StartJump)
        {
            e.speed = 25;
            Debug.Log("Jump");
            rb.AddForce(new Vector2(rb.velocity.x, JumpPower), ForceMode2D.Force);
            if (this.transform.position.y > 0.4)
            {
                Debug.Log(this.transform.position);
                StartJump = false;
                e.speed = 200;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Ground")
        {
            OnGround = true;
        }
    }

}
