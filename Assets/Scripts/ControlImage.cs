using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlImage : MonoBehaviour
{

    private Vector2 EndPos1 = new Vector2(0.003f, 0.301f);
    private Vector2 EndPos2 = new Vector2(2.7f, 0.301f);
    private Vector2 StartPos;
    // Start is called before the first frame update
    void Start()
    {
        this.StartPos = this.transform.position;
        StartCoroutine(MoveAcrossScreen());
    }

    IEnumerator MoveAcrossScreen()
    {
        float timeElapsed = 0;
        while(Mathf.Abs(this.transform.position.x - EndPos1.x) > 0.01f)
        {
            if(timeElapsed < 1)
            {
                timeElapsed += Time.deltaTime;
                this.transform.position = Vector2.Lerp(StartPos, EndPos1, timeElapsed / 1);
                yield return null;
            }
        }
        yield return new WaitForSeconds(3);
        StartPos = EndPos1;
        if(EndPos1 == EndPos2)
        {
            this.gameObject.SetActive(false);
            yield break;
        }
        else
        {
            EndPos1 = EndPos2;
            yield return StartCoroutine(MoveAcrossScreen());
        }
    }

}
