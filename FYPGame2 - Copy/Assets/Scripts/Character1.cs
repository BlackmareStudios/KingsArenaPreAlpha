using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character1 : MonoBehaviour
{
    // Prevent character interaction unless game starts
    public GameObject gameControllerObj;
    public ArenaCountDownStart gameCountDownScript;
    
    //  Is the attack range touching the opponent
    public bool isTouchingOtherPlayer = false;
    public GameObject opponentObject;

    // Opponents tag
    public string opponentTag;

    // Listen and change the health variables
    public GameObject healthObj;
    public PlayerHealth healthScript;

    // Access to opponent's movement script and see if it is blocking or not
    public GameObject opponentMovementObj;
    public BasicPlayerMovement opponentMovementScript;

    // Access to this player's movement script to see if it is stunned or not
    public GameObject thisMovementObj;
    public BasicPlayerMovement thisMovementScript;

    // Attack cooldown for character 1
    private float delayAmount = 0.5f;
    private float timeDelay = 0;

    // Push non static props
    public bool isTouchingProp;

    // Skill button
    public bool isUsingSkill;

    // Skill feedback
    public Image skillFeed;
    public Sprite unusedSkill;
    public Sprite usedSkill;
    public Sprite cooldownSkill;

    // Duration for the skill
    private float timeRemaining;
    private float timeSet;
    private bool startCounting;

    // Duration for the skill cooldown
    private float timeRemaining2;
    private float timeSet2;
    private bool startCounting2;

    private bool isCooldownOn;

    // Check if opponent is using character 1 skill
    public GameObject opponentCharacterObj;
    public Character1 opponentCharacterScript;

    // String for attack button
    public string playerAttackInput = "";

    // String for skill button
    public string playerSkillInput = "";

    // String for block button
    public string playerBlockInput = "";

    // Enemy knockback loop
    public bool loop;
    public float loopDelay;

    //Access prop script and push it
    private BarrelScript propScript;

    // Use this for initialization
    void Start()
    {
        gameControllerObj = GameObject.Find("GameController");
        gameCountDownScript = gameControllerObj.GetComponent<ArenaCountDownStart>();

        isUsingSkill = false;

        timeSet = 2.0f;
        timeRemaining = timeSet;
        startCounting = false;

        timeSet2 = 2.0f;
        timeRemaining2 = timeSet2;
        startCounting2 = false;

        isCooldownOn = false;

        healthObj = GameObject.Find("GameController");
        healthScript = healthObj.GetComponent<PlayerHealth>();

        loop = false;
        loopDelay = 0.1f;

        isTouchingProp = false;

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
        }
    }

    // Update is called once per frame
    void Update()
    {
        //print(isTouchingPlayer2);
        //print (isCooldownOn);
        //print(loopDelay);
        //print(isTouchingProp);

        // Player using skill
        if (Input.GetButtonDown(playerSkillInput) && gameCountDownScript.startMatch == true && thisMovementScript.isStunned == false)
        {
            // Disable skill usage when the game is paused
            if (Time.timeScale != 0)
            {
                // Player can use the skill if it is not in cooldown
                if (isCooldownOn == false)
                {
                    // Skill label will disappear
                    isUsingSkill = true;
                    // Start counting down before you can use your skill again
                    startCounting = true;
                }
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
        // Start the cooldown when the skill duration is over
        if (startCounting2 == true)
        {
            if (timeRemaining2 > 0)
            {
                timeRemaining2 -= Time.deltaTime;
            }
            else if (timeRemaining2 <= 0)
            {
                finishedCountdown2();
            }

            //input skill effects here
            //print("SKILL IS ACTIVE");
        }

        // If enemy is within player's attack range and pressed the attack button
        if (isTouchingOtherPlayer == true && Input.GetButtonDown(playerAttackInput) && Time.time > timeDelay && gameCountDownScript.startMatch == true && thisMovementScript.isStunned == false)
        {
            timeDelay = Time.time + delayAmount;
            // If opponent blocks
            if (opponentMovementScript.isBlocking == true)
            {
                // If opponent's character 1 is using skill
                if (opponentCharacterScript.isUsingSkill == true)
                {
                    if (this.gameObject.tag == "PlayerOneRange")
                    {
                        healthScript.player2Health -= 5;
                    }
                    if (this.gameObject.tag == "PlayerTwoRange")
                    {
                        healthScript.player1Health -= 5;
                    }
                }
                // If opponent is blocking but not using skill
                else
                {
                    if (this.gameObject.tag == "PlayerOneRange")
                    {
                        loopDelay = 0.05f;
                        StartCoroutine("Loop");
                        healthScript.player2Health -= 5;
                        loop = true;
                    }
                    if (this.gameObject.tag == "PlayerTwoRange")
                    {
                        loopDelay = 0.05f;
                        StartCoroutine("Loop");
                        healthScript.player1Health -= 5;
                        loop = true;
                    }
                }
            }
            // If opponent does not block
            else
            {
                // If opponent's character 1 is using skill
                if (opponentCharacterScript.isUsingSkill == true)
                {
                    if (this.gameObject.tag == "PlayerOneRange")
                    {
                        healthScript.player2Health -= 5;
                    }
                    if (this.gameObject.tag == "PlayerTwoRange")
                    {
                        healthScript.player1Health -= 5;
                    }
                }
                // If opponent is not blocking and not using skill
                else
                {
                    if (this.gameObject.tag == "PlayerOneRange")
                    {
                        loopDelay = 0.1f;
                        StartCoroutine("Loop");
                        healthScript.player2Health -= 10;
                        loop = true;
                    }
                    if (this.gameObject.tag == "PlayerTwoRange")
                    {
                        loopDelay = 0.1f;
                        StartCoroutine("Loop");
                        healthScript.player1Health -= 10;
                        loop = true;
                    }
                }
            }

        }

        // If a non static prop is within player's attack range and presses the attack button
        if (isTouchingProp == true && Input.GetButtonDown(playerAttackInput) && gameCountDownScript.startMatch == true && thisMovementScript.isStunned == false)
        {
            // Trigger different booleans depending on which player is using this character
            if (this.gameObject.tag == "PlayerOneRange")
            {
                propScript.pushThisFromP1 = true;
            }
            if (this.gameObject.tag == "PlayerTwoRange")
            {
                propScript.pushThisFromP2 = true;
            }

            propScript.isMoving = true;
        }

        if (loop == true)
        {
            opponentObject.transform.position += transform.TransformDirection(0, 0, 0.5f);
        }

        // Display skill image
        
        // Normal overlay
        if (isUsingSkill == false && isCooldownOn == false)
        {
            skillFeed.GetComponent<Image>().sprite = unusedSkill;
        }
        // Used skill overlay
        if (isUsingSkill == true && isCooldownOn == false)
        {
            skillFeed.GetComponent<Image>().sprite = usedSkill;
        }
        // Cooldown overlay
        if (isCooldownOn == true)
        {
            skillFeed.GetComponent<Image>().sprite = cooldownSkill;
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == opponentTag)
        {
            isTouchingOtherPlayer = true;
        }
        if (hit.gameObject.tag == "nsProp")
        {
            isTouchingProp = true;
            propScript = hit.gameObject.GetComponent<BarrelScript>();
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.tag == opponentTag)
        {
            isTouchingOtherPlayer = false;
        }
        if (hit.gameObject.tag == "nsProp")
        {
            isTouchingProp = false;
            propScript = null;
        }
    }

    void finishedCountdown()
    {
        timeRemaining = timeSet;
        startCounting = false;
        isUsingSkill = false;

        // Activate second countdown
        startCounting2 = true;

        // Start cooldown
        isCooldownOn = true;
    }
    void finishedCountdown2()
    {
        timeRemaining2 = timeSet2;
        startCounting2 = false;
        isUsingSkill = false;

        // Disable cooldown when its over
        isCooldownOn = false;
    }

    IEnumerator Loop()
    {
        yield return new WaitForSeconds(loopDelay);
        loop = false;
    }
}