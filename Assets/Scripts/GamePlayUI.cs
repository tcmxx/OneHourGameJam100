using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour {
	public static GamePlayUI gamePlayUI;

    public Text scoreText;
    public Text highScoreText;
    public GameObject endGamePanel;


    void Awake(){
		gamePlayUI = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetScoreText(float score)
    {
        scoreText.text = "Your score: " + score.ToString("F1");
        scoreText.gameObject.SetActive(true);
    }

    public void SetHighScoreText(float score)
    {
        highScoreText.text = "High score: " + score.ToString("F1");
        highScoreText.gameObject.SetActive(true);
    }

    public void ShowEndGameIU()
    {
        endGamePanel.SetActive(true);
        scoreText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
    }

	public void Restart(){
		SceneManager.LoadScene ("GameScene");
	}

	public void Quit(){
		SceneManager.LoadScene ("MenuScene");
	}
}
