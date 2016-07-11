using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AppleTreeScript : MonoBehaviour {

    // Check how much apples each player has
    public int player1AppleAmt;
    public int player2AppleAmt;

    // Drop apples per few seconds
    private float timeRemaining;
    private float timeSet;
    private bool startCounting;

    // Apple prefab
    public GameObject applePrefab;

    // Prevent count down unless game starts
    public GameObject gameControllerObj;
    public ArenaCountDownStart gameCountDownScript;

    // Display the player's apple count
    public Text player1AppleDisplay;
    public Text player2AppleDisplay;

    // Use this for initialization
    void Start () {
        player1AppleAmt = 0;
        player2AppleAmt = 0;
            
        timeSet = 2.0f;
        timeRemaining = timeSet;
        startCounting = true;

        gameControllerObj = GameObject.Find("GameController");
        gameCountDownScript = gameControllerObj.GetComponent<ArenaCountDownStart>();
    }
	
	// Update is called once per frame
	void Update () {
        if (startCounting == true && gameCountDownScript.startMatch == true && GameObject.Find("Apple") == null)
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

        // Update the apple count text
        player1AppleDisplay.text = (("Apples: ") + player1AppleAmt.ToString("0") + ("/5"));
        player2AppleDisplay.text = (("Apples: ") + player2AppleAmt.ToString("0") + ("/5"));
    }

    void finishedCountdown()
    {
        timeRemaining = timeSet;
        //startCounting = false;

        SpawnApple();
    }
    
    void SpawnApple()
    {
        GameObject instantiatedProjectile = Instantiate(applePrefab, GeneratedPosition(), Quaternion.identity) as GameObject;
        //GameObject instantiatedProjectile = Instantiate(applePrefab, new Vector3(11, 10, -1), Quaternion.identity) as GameObject;
        instantiatedProjectile.gameObject.name = "Apple";
    }

    Vector3 GeneratedPosition()
    {
        float x, y, z;
        x = Random.Range(-7, -16);
        y = 10.0f;
        z = Random.Range(-1, -6);
        return new Vector3(x, y, z);
    }
}
