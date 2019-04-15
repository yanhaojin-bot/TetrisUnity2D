using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{

    private RectTransform menuUI;
    private RectTransform gameUI;
    private RectTransform pauseUI;
    private RectTransform gameOverUI;

    private Text textA;
    private Text textB;

    private Text notif;

    // Start is called before the first frame update
    void Awake()
    {
        menuUI = transform.Find("Canvas/MenuUI") as RectTransform;
        gameUI = transform.Find("Canvas/GameUI") as RectTransform;
        pauseUI = transform.Find("Canvas/PauseUI") as RectTransform;
        gameOverUI = transform.Find("Canvas/GameOverUI") as RectTransform;

        textA = transform.Find("Canvas/GameUI/TextA").GetComponent<Text>();
        textB = transform.Find("Canvas/GameUI/TextB").GetComponent<Text>();
        notif = transform.Find("Canvas/GameOverUI/Text").GetComponent<Text>();
    }

    // methods for UI changed
    public void showMenu()
    {
        menuUI.gameObject.SetActive(true);
    }

    public void hideMenu()
    {
        menuUI.gameObject.SetActive(false);
    }

    public void showGameUI()
    {
        gameUI.gameObject.SetActive(true);
        
    }

    public void updateGameUI(String A, String B)
    {
        this.textA.text = A;
        this.textB.text = B;
    }

    public void showPause()
    {Debug.Log("showPauseUI");
        pauseUI.gameObject.SetActive(true);
        
    }

    public void hidePause()
    {
        pauseUI.gameObject.SetActive(false);
        Debug.Log("hidePauseUI");
    }

    public void showGameOverUI(String notif)
    {
        
        this.notif.text = notif;
        gameOverUI.gameObject.SetActive(true);

    }

    public void hideGameOverUI()
    {
        gameObject.gameObject.SetActive(false);
    }
}
