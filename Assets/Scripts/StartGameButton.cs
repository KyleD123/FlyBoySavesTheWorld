using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public Button btn;
    public Sprite onHoverSprite;
    public Sprite exitHoverSprite;


    private void Start()
    {

        btn.onClick.AddListener(() => { StartGame(); });

    }

    public void OnMouseEnter()
    {
        btn.gameObject.GetComponent<Image>().sprite = onHoverSprite;
    }

    public void OnMouseExit()
    {
        btn.gameObject.GetComponent<Image>().sprite = exitHoverSprite;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
