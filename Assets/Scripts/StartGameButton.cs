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

    private AudioSource audioSrc;

    private void Start()
    {
        audioSrc = this.GetComponent<AudioSource>();
        btn.onClick.AddListener(() => { StartGame(); });

    }

    public void OnMouseEnter()
    {
        btn.gameObject.GetComponent<Image>().sprite = onHoverSprite;
        audioSrc.Play();
    }

    public void OnMouseExit()
    {
        btn.gameObject.GetComponent<Image>().sprite = exitHoverSprite;
        audioSrc.Stop();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
