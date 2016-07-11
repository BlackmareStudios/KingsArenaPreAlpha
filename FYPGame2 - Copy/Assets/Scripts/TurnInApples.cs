using UnityEngine;
using System.Collections;

public class TurnInApples : MonoBehaviour {

    //Listen and change the apple tree script
    public GameObject gameControllerObject;
    public AppleTreeScript appleTreeScript;

    // Listen and change the health variables
    public GameObject gameControllerObj;
    public PlayerHealth healthScript;

    // Use this for initialization
    void Start () {
        gameControllerObject = GameObject.Find("GameController");
        appleTreeScript = gameControllerObject.GetComponent<AppleTreeScript>();

        gameControllerObj = GameObject.Find("GameController");
        healthScript = gameControllerObj.GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "PlayerOneBox")
        {
            //print("FFS1");
            if (appleTreeScript.player1AppleAmt == 5)
            {
                appleTreeScript.player1AppleAmt = 0;
                print("Player 1 apples redeemed!");
                healthScript.player1Health += 30;
            }
        }
        if (hit.gameObject.tag == "PlayerTwoBox")
        {
            //print("FFS2");
            if (appleTreeScript.player2AppleAmt == 5)
            {
                appleTreeScript.player2AppleAmt = 0;
                print("Player 2 apples redeemed!");
                healthScript.player2Health += 30;
            }
        }
    }
}
