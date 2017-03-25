using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour {

    [SerializeField]
    private bool dragging;
    private Vector3 lastPosition;
    public float level1Req;
    public float level2Req;

    public Transform midPositoin;
    public Transform rightPosition;
    public Transform leftPosition;
    public Transform upPosition;
    public Transform downPosition;

    public SpriteRenderer sRenderer;
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite rightSprite;
    public Sprite leftSprite;
    public Sprite midSprite;
    public Sprite tiredSprite;

    public Human human;

    int lastRightLevel;
    int lastUpLevel;




    public int stamina;
    public int maxStamina = 100;

    public float noMoveTimeInterval = 1;
    private float noMoveTimer;
    
    public AudioClip sfx;

    // Use this for initialization
    void Start () {
        dragging = false;
        transform.position = midPositoin.position;
    }
	
	// Update is called once per frame
	void Update () {
		if(stamina <= 0)
        {
            Tired();
        }
	}

    private void Tired()
    {
        
        GetComponent<PlayerInput>().enabled = false;
        sRenderer.sprite = tiredSprite;
        transform.position = midPositoin.position;
        GameController.Instance.LoseGame();
    }

    private void Shake(int level)
    {

        if (level > 0)
        {
            transform.position = rightPosition.position;
            sRenderer.sprite = rightSprite;
        }
        else if (level < 0)
        {
            transform.position = leftPosition.position;
            sRenderer.sprite = leftSprite;
        }
        else
        {
            transform.position = midPositoin.position;
            sRenderer.sprite = midSprite;
        }

        human.ReduceHoldingLevel(Mathf.Abs(lastRightLevel - level));
        human.SetPositionLevel(true, level);
        if (lastRightLevel != level)
        {
            stamina--;
        }

        

        lastRightLevel = level;
    }
    private void Jump(int level)
    {

        if(level > 0)
        {
            transform.position = upPosition.position;
            sRenderer.sprite = upSprite;
        }
        else if(level < 0)
        {
            transform.position = downPosition.position;
            sRenderer.sprite = downSprite;
        }
        else
        {
            transform.position = midPositoin.position;
            sRenderer.sprite = midSprite;
        }

        human.ReduceHoldingLevel(Mathf.Abs(lastUpLevel - level));
        human.SetPositionLevel(false, level);
        if (lastUpLevel != level)
        {
            stamina--;
        }


        lastUpLevel = level;
    }



    public void MousePosition(Vector3 position)
    {

        if (!dragging)
        {
            Jump(0);
            Shake(0);
            return;
        }
        Vector3 diff = position - lastPosition;


        bool up = diff.y > 0;
        bool right = diff.x > 0;
        int upLevel, rightLevel;
        if(Mathf.Abs(diff.y) > level2Req)
        {
            upLevel = 2;
        }
        else if (Mathf.Abs(diff.y) > level1Req)
        {
            upLevel = 1;
        }
        else
        {
            upLevel = 0;
        }
        if (Mathf.Abs(diff.x) > level2Req)
        {
            rightLevel = 2;
        }
        else if (Mathf.Abs(diff.x) > level1Req)
        {
            rightLevel = 1;
        }
        else
        {
            rightLevel = 0;
        }


        bool reset = false;
        if(rightLevel == 0 && upLevel == 0)
        {
            noMoveTimer -= Time.deltaTime;
        }
        else
        {
            noMoveTimer = noMoveTimeInterval;
        }

        if(noMoveTimer <= 0)
        {
            reset = true;
            noMoveTimer = noMoveTimeInterval;
        }
        
        if (rightLevel != 0)
            Shake((right ? 1 : -1) * rightLevel);
        else if(upLevel != 0)
            Jump((up?1:-1)*upLevel);
        else if (reset)
        {
            Jump(0);
            Shake(0);
        }
        stamina--;

        lastPosition = position;
    }




    public void OnPointerDown()
    {
        dragging = true;
    }
    public void OnPointerUp()
    {
        dragging = false;
    }
}
