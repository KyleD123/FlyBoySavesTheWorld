using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public UnityEngine.UI.Button btn;

    private void Start()
    {
        btn.onClick.AddListener(() => { RetryGame(); });
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
