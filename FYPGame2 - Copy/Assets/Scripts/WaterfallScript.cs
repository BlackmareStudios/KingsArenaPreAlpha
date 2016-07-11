using UnityEngine;
using System.Collections;

public class WaterfallScript : MonoBehaviour {

    // Move the players when they are touching the waterfall
    public bool player1TouchingWaterfall;
    public bool player2TouchingWaterfall;

    // Blow the players
    public GameObject PlayerOne;
    public GameObject PlayerTwo;
    // Use this for initialization
    void Start () {
        player1TouchingWaterfall = false;
        player2TouchingWaterfall = false;

        PlayerOne = GameObject.Find("Player1");
        PlayerTwo = GameObject.Find("Player2");
    }
	
	// Update is called once per frame
	void Update () {
	    if (player1TouchingWaterfall == true)
        {
            PlayerOne.transform.position += transform.TransformDirection(0, 0, -0.025f);
        }
        if (player2TouchingWaterfall == true)
        {
            PlayerTwo.transform.position += transform.TransformDirection(0, 0, -0.025f);
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "PlayerOneBox")
        {
            player1TouchingWaterfall = true;
        }
        if (hit.gameObject.tag == "PlayerTwoBox")
        {
            player2TouchingWaterfall = true;
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.tag == "PlayerOneBox")
        {
            player1TouchingWaterfall = false;
        }
        if (hit.gameObject.tag == "PlayerTwoBox")
        {
            player2TouchingWaterfall = false;
        }
    }
}
