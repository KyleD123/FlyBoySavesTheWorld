using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 100;
    private Rigidbody2D rb;
    private Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(move.x == -1)
        {
            this.rb.velocity = move * (speed/2) * Time.deltaTime;
        }
        else
        {
            this.rb.velocity = move * speed * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (this.transform.position.x <= -2.0f)
        {
            this.transform.position = new Vector2(-2f, this.transform.position.y);
        }
        else if(this.transform.position.x >= 2.07f)
        {
            this.transform.position = new Vector2(2.06f, this.transform.position.y);
        }
        else if (this.transform.position.y >= 0.96f)
        {
            this.transform.position = new Vector2(this.transform.position.x, 0.95f);
        }
    }
}
