using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Versus : MonoBehaviour
{
    private Vector2 EndPos = new Vector2(0.003f, 0.301f);
    private Vector2 StartPos;
    // Start is called before the first frame update
    void Start()
    {
        this.StartPos = this.transform.position;
        StartCoroutine(DestroySelf());
    }

    IEnumerator DestroySelf()
    {
        float timeElapsed = 0;
        while(this.transform.position.x != EndPos.x)
        {
            //this.transform.Translate(Vector2.left * 5 * Time.deltaTime);
            if(timeElapsed < 1)
            {
                timeElapsed += Time.deltaTime;
                this.transform.position = Vector2.Lerp(StartPos, EndPos, timeElapsed / 1);
            }
            yield return null;
        }
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
