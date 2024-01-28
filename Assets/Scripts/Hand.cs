using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audioSrc;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        this.transform.position = new Vector2(-1.57f, 2f);
        rb.gravityScale = 0;
        audioSrc = this.GetComponent<AudioSource>();
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
        else if(collision.transform.tag == "Ground")
        {
            audioSrc.Play();
        }
    }
}
