using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public UnityEngine.UI.Button btn;

    private void Start()
    {
        btn.onClick.AddListener(() => { StartGame(); });
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
