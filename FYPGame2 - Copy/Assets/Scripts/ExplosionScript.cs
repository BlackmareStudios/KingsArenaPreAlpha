using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;

    // Listen and change the health variables
    public GameObject healthObj;
    public PlayerHealth healthScript;

    // Use this for initialization
    void Start () {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        healthObj = GameObject.Find("GameController");
        healthScript = healthObj.GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.localScale.x < 5)
        {// Scale up the object	
            transform.localScale += new Vector3(1, 1, 1);
        }
        else
        {
            Destroy(this.gameObject);
        }
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
