using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public int player1Health;
    public int player2Health;

    // Access to LastManStanding script
    public GameObject lastManStandingGameObj;
    public LastManStanding lastManStandingScript;

    // Display the player's health
    public Text player1HealthDisplay;
    public Text player2HealthDisplay;

    // Play victory sound
    public GameObject audioControllerObj;
    public AudioFileController audioControllerScript;

    private bool playVictorySound;

    // Use this for initialization
    void Start () {
        player1Health = 100;
        player2Health = 100;

        lastManStandingGameObj = GameObject.Find("GameController");
        lastManStandingScript = lastManStandingGameObj.GetComponent<LastManStanding>();

        audioControllerObj = GameObject.Find("AudioController");
        audioControllerScript = audioControllerObj.GetComponent<AudioFileController>();

        playVictorySound = false;
    }
	
	// Update is called once per frame
	void Update () {
        // Delete player one object if the health threshold gets to 0
        if (player1Health <= 0 && playVictorySound == false)
        {
            player1Health = 0;
            lastManStandingScript.isPlayer1Alive = false;
            Destroy(GameObject.FindWithTag("PlayerOne"));
            playVictorySound = true;
            audioControllerScript.PlaySound(audioControllerScript.victorySound);
        }

        // Do not let the players get more than 100% health
        if (player1Health >= 100)
        {
            player1Health = 100;
        }
        // Do not let the players get less than 0% health
        if (player1Health <= 0)
        {
            player1Health = 0;
        }

        // Delete player two object if the health threshold gets to 0
        if (player2Health <= 0 && playVictorySound == false)
        {
            player2Health = 0;
            lastManStandingScript.isPlayer2Alive = false;
            Destroy(GameObject.FindWithTag("PlayerTwo"));
            playVictorySound = true;
            audioControllerScript.PlaySound(audioControllerScript.victorySound);
        }

        // Do not let the players get more than 100% health
        if (player2Health >= 100)
        {
            player2Health = 100;
        }

        // Update the health text
        player1HealthDisplay.text = (player1Health.ToString("0"));
        player2HealthDisplay.text = (player2Health.ToString("0"));
    }
}
