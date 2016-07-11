using UnityEngine;
using System.Collections;

public class DeathpitScript : MonoBehaviour {

    // Listen and change the health variables
    public GameObject healthObj;
    public PlayerHealth healthScript;

    // Use this for initialization
    void Start () {
        healthObj = GameObject.Find("GameController");
        healthScript = healthObj.GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    // This is meant for players to drop and die
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "PlayerOneBox")
        {
            healthScript.player1Health -= 100;
        }
        if (hit.gameObject.tag == "PlayerTwoBox")
        {
            healthScript.player2Health -= 100;
        }
    }
}
