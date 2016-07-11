using UnityEngine;
using System.Collections;

public class MagicianProjectileScript : MonoBehaviour {

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

    // Check if opponent is using character 1 skill
    public GameObject opponentCharacterObj;
    public Character1 opponentCharacterScript;

    // Access to player's character 2 script and see if this hit an opponent
    public GameObject shooterObj;
    public Character2 shooterScript;

    // Access prop script and push it
    private BarrelScript propScript;

    // Use this for initialization
    void Start () {
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

            opponentCharacterObj = GameObject.Find("P2AttackRange");
            opponentCharacterScript = opponentCharacterObj.GetComponent<Character1>();

            shooterObj = GameObject.Find("P1AttackRange");
            shooterScript = shooterObj.GetComponent<Character2>();
        }
        // If the projectile is shot from Player2
        if (this.gameObject.tag == "PlayerTwoProjectile")
        {
            //print("GAH");
            opponentTag = "PlayerOneBox";

            opponentProjectileTag = "PlayerOneProjectile";

            opponentMovementObj = GameObject.Find("Player1");
            opponentMovementScript = opponentMovementObj.GetComponent<BasicPlayerMovement>();

            opponentCharacterObj = GameObject.Find("P1AttackRange");
            opponentCharacterScript = opponentCharacterObj.GetComponent<Character1>();

            shooterObj = GameObject.Find("P2AttackRange");
            shooterScript = shooterObj.GetComponent<Character2>();
        }
    }

    // Update is called once per frame
    void Update () {
        //print(character1Script.isTouchingPlayer2);
        //print(gameObj2.tag);
        Destroy(this.gameObject, 0.25f);
    }

    void OnTriggerEnter(Collider enemy)
    {
        if (enemy.tag == opponentTag)
        {
            // If character 1 blocks and looks at this player, they will receive reduced damage
            if (opponentMovementScript.isBlocking == true)
            {
                if (opponentCharacterScript.isUsingSkill == true)
                {
                    if (this.gameObject.tag == "PlayerOneProjectile")
                    {
                        healthScript.player2Health -= 5;
                    }
                    if (this.gameObject.tag == "PlayerTwoProjectile")
                    {
                        healthScript.player1Health -= 5;
                    }
                    Destroy(this.gameObject);
                }
                else {
                    if (this.gameObject.tag == "PlayerOneProjectile")
                    {
                        healthScript.player2Health -= 5;
                    }
                    if (this.gameObject.tag == "PlayerTwoProjectile")
                    {
                        healthScript.player1Health -= 5;
                    }
                    Destroy(this.gameObject);
                    shooterScript.loop = true;
                }
            }
            else
            {
                // If character 1 uses skill, it takes no damage and knockback at all
                if (opponentCharacterScript.isUsingSkill == true)
                {
                    //print("FULLY BLOCKED");
                    if (this.gameObject.tag == "PlayerOneProjectile")
                    {
                        healthScript.player2Health -= 5;
                    }
                    if (this.gameObject.tag == "PlayerTwoProjectile")
                    {
                        healthScript.player1Health -= 5;
                    }
                    Destroy(this.gameObject);
                }
                else
                {
                    if (this.gameObject.tag == "PlayerOneProjectile")
                    {
                        healthScript.player2Health -= 10;
                    }
                    if (this.gameObject.tag == "PlayerTwoProjectile")
                    {
                        healthScript.player1Health -= 10;
                    }
                    Destroy(this.gameObject);
                    shooterScript.loop = true;
                }
            }
        }

        if (enemy.gameObject.tag == "WallCollider")
        {
            Destroy(this.gameObject);
        }

        if (enemy.gameObject.tag == "nsProp")
        {
            propScript = enemy.gameObject.GetComponent<BarrelScript>();
            propScript.isMoving = true;
            // Trigger different booleans depending on which player is using this character
            if (this.gameObject.tag == "PlayerOneProjectile")
            {
                propScript.pushThisFromP1 = true;
            }
            if (this.gameObject.tag == "PlayerTwoProjectile")
            {
                propScript.pushThisFromP2 = true;
            }
            Destroy(this.gameObject);
        }

        if (enemy.gameObject.tag == opponentProjectileTag)
        {
            Destroy(this.gameObject);
        }

        /*
        // If the projectile hits everything but the player one
        if (enemy.tag != "PlayerOneBox" && enemy.tag != "PlayerOneRange" && enemy.tag != "PlayerTwoRange" && enemy.tag != "PlayerTwoBox" && enemy.tag != "BlockNorth" && enemy.tag != "BlockSouth" && enemy.tag != "BlockEast" && enemy.tag != "BlockWest")
        {
            Destroy(this.gameObject);
        }
        */
    }
}
