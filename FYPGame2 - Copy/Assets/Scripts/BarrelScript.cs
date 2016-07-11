using UnityEngine;
using System.Collections;

public class BarrelScript : MonoBehaviour {

    public bool isMoving;

    // Check which player was the one that pushed this prop
    public bool pushThisFromP1;
    public bool pushThisFromP2;

    // Track player object
    public GameObject PlayerOne;
    public GameObject PlayerTwo;

    // Listen and change the health variables
    public GameObject gameControllerObj;
    public PlayerHealth healthScript;

    //Listen to the game controller to see which wind direction is it moving
    public WindDirection windScript;

    // Player 1 knockback
    public bool p1Knockback;

    // Player 2 knockback
    public bool p2Knockback;

    // Push force
    private int pushForce;

    // Use this for initialization
    void Start () {
        isMoving = false;

        pushThisFromP1 = false;

        PlayerOne = GameObject.Find("Player1");
        PlayerTwo = GameObject.Find("Player2");

        gameControllerObj = GameObject.Find("GameController");
        healthScript = gameControllerObj.GetComponent<PlayerHealth>();

        //windScript = gameControllerObj.GetComponent<WindDirection>();

        p1Knockback = false;
        p2Knockback = false;

        pushForce = 100;
    }
	
	// Update is called once per frame
	void Update () {
        // If player one was the one hitting this
        if (pushThisFromP1 == true && isMoving == true)
        {
            transform.LookAt(transform.position + PlayerOne.transform.rotation * Vector3.forward, PlayerOne.transform.rotation * Vector3.up);
            transform.position += transform.TransformDirection(0, 0, 0.5f);
            //GetComponent<Rigidbody>().AddForce(transform.TransformDirection(0, 0, pushForce));
            StartCoroutine("KnockThis1");
        }

        // If player two was the one hitting this
        if (pushThisFromP2 == true && isMoving == true)
        {
            transform.LookAt(transform.position + PlayerTwo.transform.rotation * Vector3.forward, PlayerTwo.transform.rotation * Vector3.up);
            transform.position += transform.TransformDirection(0, 0, 0.5f);
            //GetComponent<Rigidbody>().AddForce(transform.TransformDirection(0, 0, pushForce));
            StartCoroutine("KnockThis2");
        }

        if (p1Knockback == true)
        {
            PlayerOne.transform.position += transform.TransformDirection(0, 0, 0.25f);
        }

        if (p2Knockback == true)
        {
            PlayerTwo.transform.position += transform.TransformDirection(0, 0, 0.25f);
        }
    }

    IEnumerator KnockThis1()
    {
        yield return new WaitForSeconds(0.1f);
        pushThisFromP1 = false;
    }

    IEnumerator KnockThis2()
    {
        yield return new WaitForSeconds(0.1f);
        pushThisFromP2 = false;
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "PlayerOneBox")
        {
            //print("YO1");
            if (pushThisFromP2 == true && isMoving == true)
            {
                StopMoving();
                healthScript.player1Health -= 5;

                StartCoroutine("KnockbackPlayer1");
                p1Knockback = true;
            }
        }
        if (hit.gameObject.tag == "PlayerTwoBox")
        {
            //print("YO2");
            if (pushThisFromP1 == true && isMoving == true)
            {
                StopMoving();
                healthScript.player2Health -= 5;

                StartCoroutine("KnockbackPlayer2");
                p2Knockback = true;
            }
        }
    }

    void StopMoving()
    {
        isMoving = false;
    }

    IEnumerator KnockbackPlayer1()
    {
        yield return new WaitForSeconds(0.1f);
        p1Knockback = false;
    }

    IEnumerator KnockbackPlayer2()
    {
        yield return new WaitForSeconds(0.1f);
        p2Knockback = false;
    }
}
