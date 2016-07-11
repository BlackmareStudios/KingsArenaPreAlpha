using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character3 : MonoBehaviour {
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

    // Access to this player's movement script to see if it is stunned or not
    public GameObject thisMovementObj;
    public BasicPlayerMovement thisMovementScript;

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
            thisMovementObj = GameObject.Find("Player1");
            thisMovementScript = thisMovementObj.GetComponent<BasicPlayerMovement>();

            opponentTag = "PlayerTwo";

            opponentObject = GameObject.Find("Player2");
        }

        if (this.gameObject.tag == "PlayerTwoRange")
        {
            thisMovementObj = GameObject.Find("Player2");
            thisMovementScript = thisMovementObj.GetComponent<BasicPlayerMovement>();

            opponentTag = "PlayerOne";

            opponentObject = GameObject.Find("Player1");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //print(loopDelay);

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
            loopDelay = 0.1f;
            StartCoroutine("Loop");
            loop = true;
            opponentObject.transform.position += transform.TransformDirection(0, 0, 0.5f);
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

    IEnumerator Loop()
    {
        yield return new WaitForSeconds(loopDelay);
        loop = false;
    }
}