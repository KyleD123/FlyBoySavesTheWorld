using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int speed;

    private Rigidbody2D rb;

    public GameObject hand;

    public bool inPosition = false;

    // Start is called before the first frame update
    void Start()
    {
        this.hand = GameObject.Find("Hand");
        rb = this.GetComponent<Rigidbody2D>();
        StartCoroutine(StartFight());
    }


    void FixedUpdate()
    {
        if(this.transform.position.x > 1.355f && !inPosition)
        {
            rb.AddForce(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            inPosition = true;
            this.transform.position = new Vector2(1.355f, this.transform.position.y);
        }
    }


    IEnumerator StartFight()
    {
        yield return new WaitForSeconds(3);
        yield return StartCoroutine(Slap1());
    }

    IEnumerator Slap1()
    {
        hand.GetComponent<Rigidbody2D>().gravityScale = 0;
        hand.transform.position = new Vector2(-1.57f, 2.5f);
        yield return new WaitForSeconds(3);
        hand.GetComponent<Rigidbody2D>().gravityScale = 1f;
        yield return new WaitForSeconds(2);
        hand.GetComponent<Rigidbody2D>().gravityScale = -1f;
        yield return StartCoroutine(Slap2());
    }

    IEnumerator Slap2()
    {
        hand.GetComponent<Rigidbody2D>().gravityScale = 0;
        hand.transform.position = new Vector2(-0.2f, 2.5f);
        yield return new WaitForSeconds(3);
        hand.GetComponent<Rigidbody2D>().gravityScale = 1f;
        yield return new WaitForSeconds(2);
        hand.GetComponent<Rigidbody2D>().gravityScale = -1f;
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
