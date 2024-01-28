using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (!gm.BossBattle)
        {
            this.transform.position = new Vector2(-1.57f, 1.78f);
            rb.gravityScale = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Debug.Log("Hand Smacked The Fly");
            Destroy(collision.gameObject);
        }
        else if(collision.transform.name != "Boss" && collision.transform.tag != "Ground")
        {
            Destroy(collision.gameObject);
        }
    }
}
