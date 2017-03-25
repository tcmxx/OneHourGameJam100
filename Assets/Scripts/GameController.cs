using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController Instance;

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
        GamePlayUI.gamePlayUI.SetEndGameText("I Made This!");
    }
}
