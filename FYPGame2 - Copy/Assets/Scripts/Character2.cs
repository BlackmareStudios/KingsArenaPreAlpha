using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character2 : MonoBehaviour
{
    // Prevent character interaction unless game starts
    public GameObject gameControllerObj;
    public ArenaCountDownStart gameCountDownScript;
    
    // Is the attack range touching the opponent
    public bool isTouchingOtherPlayer = false;
    public GameObject opponentObject;

    // Opponents tag
    public string opponentTag;

    // Character 2 shoots out a magician projectile
    private float delayAmount = 1.0f;
    private float timeDelay = 0;
    public Rigidbody projectile;
    private float speed = 40;

    // Access to opponent's movement script and see if it is blocking or not
    public GameObject opponentMovementObj;
    public BasicPlayerMovement opponentMovementScript;

    // Access to this player's movement script to see if it is stunned or not
    public GameObject thisMovementObj;
    public BasicPlayerMovement thisMovementScript;

    // Skill button
    public bool isUsingSkill;

    // Skill feedback
    public Image skillFeed;
    public Sprite unusedSkill;
    public Sprite usedSkill;

    // To teleport the whole character
    private GameObject thisCharacterObject;

    // Cooldown for the skill
    private float timeRemaining;
    private float timeSet;
    private bool startCounting;

    // Check if opponent is using character 1 skill
    public GameObject opponentCharacterObj;
    public Character1 opponentCharacterScript;

    // String for attack button
    public string playerAttackInput = "";

    // String for skill button
    public string playerSkillInput = "";

    // String for block button
    public string playerBlockInput = "";

    // Movement loop
    public bool loop;
    public float loopDelay;

    // Play projectile sound
    public GameObject audioControllerObj;
    public AudioFileController audioControllerScript;

    // Use this for initialization
    void Start()
    {
        gameControllerObj = GameObject.Find("GameController");
        gameCountDownScript = gameControllerObj.GetComponent<ArenaCountDownStart>();

        isUsingSkill = false;

        timeSet = 2.0f;
        timeRemaining = timeSet;
        startCounting = false;

        loop = false;
        loopDelay = 0.1f;

        //audioControllerObj = GameObject.Find("AudioController");
        //audioControllerScript = audioControllerObj.GetComponent<AudioFileController>();

        // Check who is using this character
        CheckThisTag();
    }

    void CheckThisTag()
    {
        if (this.gameObject.tag == "PlayerOneRange")
        {
            //print("YES");
            opponentMovementObj = GameObject.Find("Player2");
            opponentMovementScript = opponentMovementObj.GetComponent<BasicPlayerMovement>();

            thisMovementObj = GameObject.Find("Player1");
            thisMovementScript = thisMovementObj.GetComponent<BasicPlayerMovement>();

            opponentTag = "PlayerTwo";

            opponentObject = GameObject.Find("Player2");

            opponentCharacterObj = GameObject.Find("P2AttackRange");
            opponentCharacterScript = opponentCharacterObj.GetComponent<Character1>();

            thisCharacterObject = GameObject.Find("Player1");
        }

        if (this.gameObject.tag == "PlayerTwoRange")
        {
            opponentMovementObj = GameObject.Find("Player1");
            opponentMovementScript = opponentMovementObj.GetComponent<BasicPlayerMovement>();

            thisMovementObj = GameObject.Find("Player2");
            thisMovementScript = thisMovementObj.GetComponent<BasicPlayerMovement>();

            opponentTag = "PlayerOne";

            opponentObject = GameObject.Find("Player1");

            opponentCharacterObj = GameObject.Find("P1AttackRange");
            opponentCharacterScript = opponentCharacterObj.GetComponent<Character1>();

            thisCharacterObject = GameObject.Find("Player2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //print(isTouchingPlayer2);
        //print (isCooldownOn);
        //print(loopDelay);

        // Player using skill
        if (Input.GetButtonDown(playerSkillInput) && gameCountDownScript.startMatch == true && thisMovementScript.isStunned == false)
        {
            // Disable skill usage when the game is paused
            if (Time.timeScale != 0)
            {
                // Teleportation
                if (isUsingSkill == false)
                {
                    thisCharacterObject.transform.position += thisCharacterObject.transform.forward * 4;
                }
                // Skill label will disappear
                isUsingSkill = true;
                // Start counting down before you can use your skill again
                startCounting = true;
            } 
        }

        // Start the duration when the skill button is pressed
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

            //input skill effects here
            //print("SKILL IS ACTIVE");
        }

        if (Input.GetButtonDown(playerAttackInput) && Time.time > timeDelay && gameCountDownScript.startMatch == true && thisMovementScript.isStunned == false)
        {
            timeDelay = Time.time + delayAmount;
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;

            //audioControllerScript.PlaySound(audioControllerScript.magicianAttackSound);

            // Give a tag to the projectile
            if (this.gameObject.tag == "PlayerOneRange")
            {
                instantiatedProjectile.gameObject.tag = "PlayerOneProjectile";
            }
            if (this.gameObject.tag == "PlayerTwoRange")
            {
                instantiatedProjectile.gameObject.tag = "PlayerTwoProjectile";
            }
            
            // Make the projectile move
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        }

        if (loop == true)
        {
            // If character 1 blocks and looks at this player, they will receive reduced damage
            if (opponentMovementScript.isBlocking == true)
            {
                if (opponentCharacterScript.isUsingSkill == true)
                {
                    loop = false;
                }
                else {
                    loopDelay = 0.05f;
                    StartCoroutine("Loop");
                    loop = true;
                }
            }
            else
            {
                // If character 1 uses skill, it takes no damage and knockback at all
                if (opponentCharacterScript.isUsingSkill == true)
                {
                    loop = false;
                }
                else
                {
                    loopDelay = 0.1f;
                    StartCoroutine("Loop");
                    loop = true;
                }
            }
            // Don't move player 1 if he is using skill
            if (opponentCharacterScript.isUsingSkill == false)
            {
                opponentObject.transform.position += transform.TransformDirection(0, 0, 0.5f);
            }

        }

        // Black overlay
        if (isUsingSkill == true)
        {
            //GUI.Label(new Rect(285, 100, 100, 100), usedSkill);
            skillFeed.GetComponent<Image>().sprite = usedSkill;
        }
        // Normal overlay
        if (isUsingSkill == false)
        {
            //GUI.Label(new Rect(285, 100, 100, 100), unusedSkill);
            skillFeed.GetComponent<Image>().sprite = unusedSkill;
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == opponentTag)
        {
            isTouchingOtherPlayer = true;
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.tag == opponentTag)
        {
            isTouchingOtherPlayer = false;
        }
    }

    void finishedCountdown()
    {
        timeRemaining = timeSet;
        startCounting = false;
        isUsingSkill = false;
    }

    IEnumerator Loop()
    {
        yield return new WaitForSeconds(loopDelay);
        loop = false;
    }
}