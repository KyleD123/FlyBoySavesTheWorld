using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReloadStartScreen());
    }

    IEnumerator ReloadStartScreen()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("StartScreen");
    }

}
