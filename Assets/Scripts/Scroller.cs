using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float speed = 4f;
    private Vector3 StartPosition;

    private bool KeepScrolling = true;

    // Start is called before the first frame update
    void Start()
    {
        this.StartPosition = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        KeepScrolling = !FindObjectOfType<GameManager>().BossBattle;
        if (KeepScrolling)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x < -4.211f)
            {
                transform.position = StartPosition;
            }
        }
    }
}
