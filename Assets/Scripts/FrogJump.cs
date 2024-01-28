using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogJump : MonoBehaviour
{
    public float JumpPower = 35;
    private Rigidbody2D rb;
    private GameObject player;

    public bool OnGround = true;
    public bool StartJump = true;

    Animator anime;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("GameManager").GetComponent<GameManager>().Player;
        anime = this.GetComponentInChildren<Animator>();
        anime.Play("EnemyFrog_Idle");
        StartCoroutine(JumpWhenInRange());
    }

    IEnumerator JumpWhenInRange()
    {
        while (true)
        {
            if (player == null) yield break;
            if (Vector2.Distance(this.transform.position, player.transform.position) < 1.75f)
            {
                rb.AddForce(new Vector2(0, JumpPower * Random.Range(0.4f, 1.1f)), ForceMode2D.Impulse);
                OnGround = false;
                anime.SetBool("OnGround", OnGround);
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
            if(anime != null)
                anime.SetBool("OnGround", OnGround);
        }
    }

}
