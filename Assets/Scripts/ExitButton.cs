using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public UnityEngine.UI.Button btn;

    private void Start()
    {
        btn.onClick.AddListener(() => { ExitGame(); });
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
