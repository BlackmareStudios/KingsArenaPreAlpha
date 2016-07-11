using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WindDirection : MonoBehaviour {
    private bool north, south, east, west, noDirection;

    // 30 seconds before the wind blows
    private float timeRemaining;
    private float timeSet;
    private bool startCounting;

    // Duration for wind blowing
    private float timeRemaining1;
    private float timeSet1;
    private bool startCounting1;

    // Blow the players
    public GameObject PlayerOne;
    public GameObject PlayerTwo;

    // See if the players are inside the block zones
    public GameObject p1Obj;
    public PlayerController p1Script;

    public GameObject p2Obj;
    public PlayerController p2Script;

    // Text for the wind timer and duration
    public Text windTimer;
    public Text windDuration;

    // Visual feedback for the wind
    public Image windDirectionFeed;
    public Sprite fromNorth, fromSouth, fromEast, fromWest, fromNowhere;

    // Prevent count down unless game starts
    public GameObject gameControllerObj;
    public ArenaCountDownStart gameCountDownScript;

    // Use this for initialization
    void Start () {
        north = false;
        south = false;
        east = false;
        west = false;
        noDirection = true;

        timeSet = 30.0f;
        timeRemaining = timeSet;
        startCounting = true;

        timeSet1 = 5.0f;
        timeRemaining1 = timeSet1;
        startCounting1 = false;

        PlayerOne = GameObject.Find("Player1");
        PlayerTwo = GameObject.Find("Player2");

        p1Obj = GameObject.Find("P1Controller");
        p1Script = p1Obj.GetComponent<PlayerController>();

        p2Obj = GameObject.Find("P2Controller");
        p2Script = p2Obj.GetComponent<PlayerController>();

        gameControllerObj = GameObject.Find("GameController");
        gameCountDownScript = gameControllerObj.GetComponent<ArenaCountDownStart>();
    }
	
	// Update is called once per frame
	void Update () {
        //print(beforeEffect);
        //PlayerOne.transform.position += transform.TransformDirection(0, 0, 0.05f);

        // Push players depending on wind direction
        if (north == true)
        {
            // Check if player one and two are touching the north block
            if (p1Script.isTouchingBlockNorth == false && PlayerOne != null)
            {
                PlayerOne.transform.position += transform.TransformDirection(0, 0, -0.08f);
            }

            if (p2Script.isTouchingBlockNorth == false && PlayerTwo != null)
            {
                PlayerTwo.transform.position += transform.TransformDirection(0, 0, -0.08f);
            }
        }
        if (south == true)
        {
            // Check if player one and two are touching the south block
            if (p1Script.isTouchingBlockSouth == false && PlayerOne != null)
            {
                PlayerOne.transform.position += transform.TransformDirection(0, 0, 0.08f);
            }
            if (p2Script.isTouchingBlockSouth == false && PlayerTwo != null)
            {
                PlayerTwo.transform.position += transform.TransformDirection(0, 0, 0.08f);
            }
        }
        if (east == true)
        {
            // Check if player one and two are touching the east block
            if (p1Script.isTouchingBlockEast == false && PlayerOne != null)
            {
                PlayerOne.transform.position += transform.TransformDirection(-0.08f, 0, 0);
            }
            if (p2Script.isTouchingBlockEast == false && PlayerTwo != null)
            {
                PlayerTwo.transform.position += transform.TransformDirection(-0.08f, 0, 0);
            }
        }
        if (west == true)
        {
            // Check if player one and two are touching the west block
            if (p1Script.isTouchingBlockWest == false && PlayerOne != null)
            {
                PlayerOne.transform.position += transform.TransformDirection(0.08f, 0, 0);
            }
            if (p2Script.isTouchingBlockWest == false && PlayerTwo != null)
            {
                PlayerTwo.transform.position += transform.TransformDirection(0.08f, 0, 0);
            }
        }

        if (startCounting == true && gameCountDownScript.startMatch == true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else if (timeRemaining <= 0)
            {
                finishedCountdown();
            }
        }

        if (startCounting1 == true)
        {
            if (timeRemaining1 > 0)
            {
                timeRemaining1 -= Time.deltaTime;
            }
            else if (timeRemaining1 <= 0)
            {
                finishedCountdown1();
            }
        }

        // Timer/cooldown for wind blowing
        windTimer.text = (timeRemaining.ToString("0"));

        // Duration for wind blowing
        windDuration.text = (timeRemaining1.ToString("0"));


        if (north == true)
        {
            windDirectionFeed.GetComponent<Image>().sprite = fromNorth;
        }
        if (south == true)
        {
            windDirectionFeed.GetComponent<Image>().sprite = fromSouth;
        }
        if (east == true)
        {
            windDirectionFeed.GetComponent<Image>().sprite = fromEast;
        }
        if (west == true)
        {
            windDirectionFeed.GetComponent<Image>().sprite = fromWest;
        }
        if (noDirection == true)
        {
            windDirectionFeed.GetComponent<Image>().sprite = fromNowhere;
        }
    }

    void finishedCountdown()
    {
        timeRemaining = timeSet;
        startCounting = false;
        startCounting1 = true;

        noDirection = false;

        GeneratedDirection();
    }
    void finishedCountdown1()
    {
        timeRemaining1 = timeSet1;
        startCounting1 = false;

        noDirection = true;
        north = false;
        south = false;
        east = false;
        west = false;

        startCounting = true;
    }

    int GeneratedDirection()
    {
        int directionResult = Random.Range(1, 5);
        //print(attackResult);
        if (directionResult == 1)
        {
            north = true;
            south = false;
            east = false;
            west = false;

            noDirection = false;
        }
        if (directionResult == 2)
        {
            north = false;
            south = true;
            east = false;
            west = false;

            noDirection = false;
        }
        if (directionResult == 3)
        {
            north = false;
            south = false;
            east = true;
            west = false;

            noDirection = false;
        }
        if (directionResult == 4)
        {
            north = false;
            south = false;
            east = false;
            west = true;

            noDirection = false;
        }

        return directionResult;
    }
}
