using UnityEngine;
using System.Collections;

public class BridgeScript : MonoBehaviour {

    // Start a timer when a player steps on a bridge
    private float timeRemaining;
    private float timeSet;
    private bool startCounting;

    public bool startDrop;

    public GameObject gameControllerObject;
    public BridgeController bridgeControllerScript;

    void Awake()
    {
        gameControllerObject = GameObject.Find("GameController");
        bridgeControllerScript = gameControllerObject.GetComponent<BridgeController>();
    }

    // Use this for initialization
    void Start () {
        timeSet = 10.0f;
        timeRemaining = timeSet;
        startCounting = false;

        startDrop = false;
    }
	
	// Update is called once per frame
	void Update () {

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

        if (startDrop == true)
        {
            transform.parent.gameObject.transform.Translate(Vector3.down * 45 * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "PlayerOneBox")
        {
            //print("FFS");
            //Start the countdown to drop and deduct the time before it drops every time it stands on the bridge
            startCounting = true;
            timeRemaining -= 1.0f;
        }
        if (hit.gameObject.tag == "PlayerTwoBox")
        {
            //print("FFS");
            //Start the countdown to drop and deduct the time before it drops every time it stands on the bridge
            startCounting = true;
            timeRemaining -= 1.0f;
        }
    }

    void finishedCountdown()
    {
        timeRemaining = timeSet;
        startCounting = false;

        startDrop = true;

        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1.5f);
        bridgeControllerScript.SpawnDelay();
        Destroy(transform.parent.gameObject);
    }
}
