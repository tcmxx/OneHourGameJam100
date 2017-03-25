using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {

    public int maxHoldingLevel;
    public int holdingLevel;
    public SpriteRenderer sRenderer;
    public Transform midPositoin;
    public Transform rightPosition;
    public Transform leftPosition;
    public Transform upPosition;
    public Transform downPosition;
    public Transform losePosition;
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite rightSprite;
    public Sprite leftSprite;
    public Sprite midSprite;
    public Sprite loseSprite;

    public Dragon dragon;

    bool lose = false;
    // Use this for initialization
    void Start () {
        SetPositionLevel(true, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReduceHoldingLevel(int num)
    {
        holdingLevel -= num;
        if(holdingLevel <= 0)
        {
            lose = true;
            dragon.GetComponent<PlayerInput>().enabled = false;
            sRenderer.sprite = loseSprite;
            transform.position = losePosition.position;
            StartCoroutine(DropCoroutine());
        }
    }

    public void SetPositionLevel(bool rightOrUp, int level)
    {
        if (lose)
            return;

        if(level == 0)
        {
            transform.position = midPositoin.position;
            sRenderer.sprite = midSprite;
        }
        else if(rightOrUp && level > 0)
        {
            transform.position = rightPosition.position;
            sRenderer.sprite = rightSprite;
        }
        else if (rightOrUp && level < 0)
        {
            transform.position = leftPosition.position;
            sRenderer.sprite = leftSprite;
        }
        else if (!rightOrUp && level > 0)
        {
            transform.position = upPosition.position;
            sRenderer.sprite = upSprite;
        }
        else if (!rightOrUp && level < 0)
        {
            transform.position = downPosition.position;
            sRenderer.sprite = downSprite;
        }
    }



    IEnumerator DropCoroutine()
    {

        yield return new WaitForSeconds(2);

        GameController.Instance.WinGame();
    }

}
