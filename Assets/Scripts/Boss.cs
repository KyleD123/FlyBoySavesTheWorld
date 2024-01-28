using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int speed;

    private Rigidbody2D rb;

    public GameObject hand;

    // Start is called before the first frame update
    void Start()
    {
        this.hand = GameObject.Find("Hand");
        rb = this.GetComponent<Rigidbody2D>();
        StartCoroutine(Slap1());
    }


    void FixedUpdate()
    {
        if(this.transform.position.x > 1.6f)
        {
            rb.AddForce(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            this.transform.position = new Vector2(1.6f, this.transform.position.y);
        }
    }

    IEnumerator Slap1()
    {
        hand.transform.position = new Vector2(-1.57f, 1.78f);
        hand.GetComponent<Rigidbody2D>().gravityScale = 0;
        yield return new WaitForSeconds(3);
        hand.GetComponent<Rigidbody2D>().gravityScale = 1f;
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(Slap2());
    }

    IEnumerator Slap2()
    {
        hand.transform.position = new Vector2(-0.2f, 1.78f);
        hand.GetComponent<Rigidbody2D>().gravityScale = 0;
        yield return new WaitForSeconds(3);
        hand.GetComponent<Rigidbody2D>().gravityScale = 1f;
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(Slap1());
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

}
