using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float speed = 4f;
    private Vector3 StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        this.StartPosition = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if(transform.position.x < -4.191f)
        {
            transform.position = StartPosition;
        }
    }
}
