using UnityEngine;
using System.Collections;

public class Magician2ProjectileScript : MonoBehaviour
{

    // Opponents tag
    public string opponentTag;

    // If this projectile hits the opponent's projectile
    public string opponentProjectileTag;

    // Listen and change the health variables
    public GameObject healthObj;
    public PlayerHealth healthScript;

    // Access to opponent's movement script and see if it is blocking or not
    public GameObject opponentMovementObj;
    public BasicPlayerMovement opponentMovementScript;

    // Access to player's character 2 script and see if this hit an opponent
    public GameObject shooterObj;
    public Character3 shooterScript;

    // Use this for initialization
    void Start()
    {
        healthObj = GameObject.Find("GameController");
        healthScript = healthObj.GetComponent<PlayerHealth>();

        // Check who is shot this projectile
        CheckThisTag();
    }

    void CheckThisTag()
    {
        // If the projectile is shot from Player1
        if (this.gameObject.tag == "PlayerOneProjectile")
        {
            //print("MAH");
            opponentTag = "PlayerTwoBox";

            opponentProjectileTag = "PlayerTwoProjectile";

            opponentMovementObj = GameObject.Find("Player2");
            opponentMovementScript = opponentMovementObj.GetComponent<BasicPlayerMovement>();

            shooterObj = GameObject.Find("P1AttackRange");
            shooterScript = shooterObj.GetComponent<Character3>();
        }
        // If the projectile is shot from Player2
        if (this.gameObject.tag == "PlayerTwoProjectile")
        {
            //print("GAH");
            opponentTag = "PlayerOneBox";

            opponentProjectileTag = "PlayerOneProjectile";

            opponentMovementObj = GameObject.Find("Player1");
            opponentMovementScript = opponentMovementObj.GetComponent<BasicPlayerMovement>();

            shooterObj = GameObject.Find("P2AttackRange");
            shooterScript = shooterObj.GetComponent<Character3>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //print(character1Script.isTouchingPlayer2);
        //print(gameObj2.tag);
        Destroy(this.gameObject, 0.25f);
    }

    void OnTriggerEnter(Collider enemy)
    {
        if (enemy.tag == opponentTag)
        {
            if (this.gameObject.tag == "PlayerOneProjectile")
            {
                healthScript.player2Health -= 10;
            }
            if (this.gameObject.tag == "PlayerTwoProjectile")
            {
                healthScript.player1Health -= 10;
            }
            //Destroy(this.gameObject);
            shooterScript.loop = true;
        }

        if (enemy.gameObject.tag == "WallCollider")
        {
            Destroy(this.gameObject);
        }

        if (enemy.gameObject.tag == opponentProjectileTag)
        {
            //Destroy(this.gameObject);
        }
    }
}