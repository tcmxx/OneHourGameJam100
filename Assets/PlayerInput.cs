using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public Dragon dragon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        dragon.MousePosition(Input.mousePosition);

        if (Input.GetMouseButtonUp(0))
        {
            dragon.OnPointerUp();
        }
	}





}
