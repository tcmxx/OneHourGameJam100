using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController Instance;
    public GameObject finalSprite;
	void Awake(){
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void WinGame()
    {
        GamePlayUI.gamePlayUI.ShowEndGameIU();
        finalSprite.SetActive(true);
    }

    public void LoseGame()
    {
        GamePlayUI.gamePlayUI.ShowEndGameIU();
        GamePlayUI.gamePlayUI.SetEndGameText("Lose!");
    }
}
