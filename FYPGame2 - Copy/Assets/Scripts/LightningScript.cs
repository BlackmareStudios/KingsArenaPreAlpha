using UnityEngine;
using System.Collections;

public class LightningScript : MonoBehaviour {
    //Listen and change the health variables
    public GameObject healthObj;
    public PlayerHealth healthScript;

    // Use this for initialization
    void Start () {
        healthObj = GameObject.Find("GameController");
        healthScript = healthObj.GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update () {
        Destroy(this.gameObject, 2);
    }

    // Touches any of the player
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "PlayerOneBox")
        {
            healthScript.player1Health -= 10;
        }
        if (hit.gameObject.tag == "PlayerTwoBox")
        {
            healthScript.player2Health -= 10;
        }
    }
}
