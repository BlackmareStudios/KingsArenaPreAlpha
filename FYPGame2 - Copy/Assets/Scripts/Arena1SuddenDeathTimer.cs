using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Arena1SuddenDeathTimer : MonoBehaviour {

    private float timeLeft = 120.0f;        //120
    private bool suddenDeath = false;

    // Cool downs between the lightning
    private float timeRemaining;
    private float timeSet;
    private bool startCounting;

    // Spawn asteroids
    public GameObject lightningPrefab;

    // Display the sudden death timer in the game world
    public Text suddenDeathTimerDisplay;
    public Text suddenDeathDisplay;

    // Prevent count down unless game starts
    public GameObject gameControllerObj;
    public ArenaCountDownStart gameCountDownScript;

    void Start() {
        timeSet = 1.0f;
        timeRemaining = timeSet;
        startCounting = false;

        suddenDeathTimerDisplay.text = ("");
        suddenDeathDisplay.text = ("");

        gameControllerObj = GameObject.Find("GameController");
        gameCountDownScript = gameControllerObj.GetComponent<ArenaCountDownStart>();
    }


    void Update()
    {
        //print(timeLeft);

        // Don't count down the sudden death until the match officially starts
        if (gameCountDownScript.startMatch == true)
        {
            timeLeft -= Time.deltaTime;
        }
        
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            suddenDeath = true;
            startCounting = true;
        }

        if (startCounting == true)
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
        
        suddenDeathTimerDisplay.text = (timeLeft.ToString("0"));
        // Show sudden death message
        if (suddenDeath == true)
        {
            suddenDeathDisplay.text = ("SUDDEN DEATH");
        }
    }

    void finishedCountdown()
    {
        timeRemaining = timeSet;
        //startCounting = false;

        int chooseLocation = Random.Range(1, 3);

        switch (chooseLocation)
        {
            case 1:
                Instantiate(lightningPrefab, GeneratedPosition(), Quaternion.identity);
                break;
            case 2:
                Instantiate(lightningPrefab, GeneratedPosition2(), Quaternion.identity);
                break;
        }
    }

    Vector3 GeneratedPosition()
    {
        float x, y, z;
        x = Random.Range(10, 22);
        y = 10.5f;
        z = Random.Range(-9, 9);
        return new Vector3(x, y, z);
    }

    Vector3 GeneratedPosition2()
    {
        float x, y, z;
        x = Random.Range(-24, -12);
        y = 10.5f;
        z = Random.Range(-1, 17);
        return new Vector3(x, y, z);
    }
}
