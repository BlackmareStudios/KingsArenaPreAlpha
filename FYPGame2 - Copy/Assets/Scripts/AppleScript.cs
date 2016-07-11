using UnityEngine;
using System.Collections;

public class AppleScript : MonoBehaviour {

    //Listen and change the apple tree script
    public GameObject gameControllerObject;
    public AppleTreeScript appleTreeScript;

   // public GameObject p1GameObj;
    // Stun the player in their movement script
    public BasicPlayerMovement player1MovementScript;

   // public GameObject p2GameObj;
    // Stun the player in their movement script
    public BasicPlayerMovement player2MovementScript;

    private bool isStunBox;

    // Use this for initialization
    void Start ()
    {
        gameControllerObject = GameObject.Find("GameController");
        appleTreeScript = gameControllerObject.GetComponent<AppleTreeScript>();

        if(GameObject.Find("Player1") != null)
            player1MovementScript = GameObject.Find("Player1").GetComponent<BasicPlayerMovement>();

        if(GameObject.Find("Player2") != null)
            player2MovementScript = GameObject.Find("Player2").GetComponent<BasicPlayerMovement>();

        isStunBox = false;

        CheckName();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //print(isStunBox);

        // Automatically destroy the apple if no player touches the apple
        Destroy(transform.parent.gameObject, 5);
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "PlayerOneBox")
        {
            //print("FFS1");
            // When the players touch the apple after it's dropped
            if (appleTreeScript.player1AppleAmt < 5)
            {
                appleTreeScript.player1AppleAmt += 1;
            }
            Destroy(transform.parent.gameObject);

            // When the players touch the button of the apple while it's dropping
            if (isStunBox == true)
            {
                //print("Player 1 Stunned");
                player1MovementScript.stunDelay = 1.0f;
                player1MovementScript.StunPlayer();
                //player1MovementScript.isStunned = true;
            }
        }
        if (hit.gameObject.tag == "PlayerTwoBox")
        {
            //print("FFS2");
            // When the players touch the apple after it's dropped
            if (appleTreeScript.player2AppleAmt < 5)
            {
                appleTreeScript.player2AppleAmt += 1;
            }
            Destroy(transform.parent.gameObject);

            // When the players touch the button of the apple while it's dropping
            if (isStunBox == true)
            {
                //print("Player 2 Stunned");
                player2MovementScript.stunDelay = 1.0f;
                player2MovementScript.StunPlayer();
                //player2MovementScript.isStunned = true;
            }
        }
    }

    void CheckName()
    {
        if (this.gameObject.name == "AppleHitBox")
        {
            isStunBox = false;
        }
        if (this.gameObject.name == "AppleLowerHitBox")
        {
            isStunBox = true;
        }
    }
}
