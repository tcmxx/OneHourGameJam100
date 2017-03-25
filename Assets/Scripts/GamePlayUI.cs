using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour {
	public static GamePlayUI gamePlayUI;

    public Text currentScoreText;
    public Text finalScoreText;
    public Text highScoreText;
    public Text endGameText;
    public GameObject endGamePanel;

    public Dragon dragonToTrack;
    public Human humanToTrack;
    public Image staminaImage;
    public Image holdingImage;

    void Awake(){
		gamePlayUI = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        staminaImage.fillAmount = (float)dragonToTrack.stamina / dragonToTrack.maxStamina;
        holdingImage.fillAmount = (float)humanToTrack.holdingLevel / humanToTrack.maxHoldingLevel;
    }

    public void SetEndGameText(string te)
    {
        endGameText.text = te;
    }

    public void SetCurrentScoreText(float score)
    {
        currentScoreText.text = "Your score: " + score.ToString("F1");
    }

    public void SetFinalScoreText(float score)
    {
        finalScoreText.text = "Your score: " + score.ToString("F1");
        finalScoreText.gameObject.SetActive(true);
    }

    public void SetHighScoreText(float score)
    {
        highScoreText.text = "High score: " + score.ToString("F1");
        highScoreText.gameObject.SetActive(true);
    }

    public void ShowEndGameIU()
    {
        endGamePanel.SetActive(true);
        finalScoreText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
    }

	public void Restart(){
		SceneManager.LoadScene ("GameScene");
	}

	public void Quit(){
		SceneManager.LoadScene ("MenuScene");
	}
}
