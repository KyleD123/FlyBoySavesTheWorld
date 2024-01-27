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

        StartCoroutine(JumpWhenInRange());
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    IEnumerator JumpWhenInRange()
    {
        while (true)
        {
            if (Vector2.Distance(this.transform.position, player.transform.position) < 1.5f)
            {
                rb.AddForce(new Vector2(0, JumpPower * Random.Range(0.2f, 1f)), ForceMode2D.Impulse);
                yield break;
            }
            else
            {
                yield return null;
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
