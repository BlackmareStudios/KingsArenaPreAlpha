using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
public class BasicPlayerMovement : MonoBehaviour {

    // Prevent movement unless game starts
    public GameObject gameControllerObj;
    public ArenaCountDownStart gameCountDownScript;
    
    // Handling
    private float rotationSpeed = 450;
    public float movementSpeed = 5;
    private float runSpeed;

    public float jumpSpeed = 20.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;

    // System
    private Quaternion targetRotation;

    // Components
    private CharacterController controller;

    // Strings to make this script share-able to other players
    public string playerHorizontalInput = "";
    public string playerVertivalInput = "";

    // Jump button
    public string playerJumpInput;

    // Blocking attacks
    public bool isBlocking;

    // String for block button
    public string playerBlockInput = "";

    // Block feedback name
    public GameObject blockFeedbObject;

    // Stun player
    public bool isStunned;
    public float stunDelay;

    // Use this for initialization
    void Start ()
    {
        gameControllerObj = GameObject.Find("GameController");
        gameCountDownScript = gameControllerObj.GetComponent<ArenaCountDownStart>();

        controller = GetComponent<CharacterController>();
        runSpeed = movementSpeed;

        isBlocking = false;

        isStunned = false;
        stunDelay = 0.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (gameCountDownScript.startMatch == true && isStunned == false)
        {
            Vector3 input = new Vector3(Input.GetAxisRaw(playerHorizontalInput), 0, Input.GetAxisRaw(playerVertivalInput));

            if (input != Vector3.zero)
            {
                targetRotation = Quaternion.LookRotation(input);
                transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
            }

            // Jump
            if (controller.isGrounded == true)
            {
                if (Input.GetButtonDown(playerJumpInput))
                {
                    moveDirection.y = jumpSpeed;
                }
            }

            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
            Vector3 motion = input;
            motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1) ? .7f : 1;
            motion *= (Input.GetButton("Run")) ? runSpeed : movementSpeed;
            //motion *= movementSpeed;

            motion += Vector3.up * -8;

            controller.Move(motion * Time.deltaTime);

            if (Input.GetButton(playerBlockInput))
            {
                // Disable blocking usage when the game is paused
                if (Time.timeScale != 0)
                {
                    isBlocking = true;
                }
            }
            else
            {
                isBlocking = false;
            }
        }
        
        // Show blocking feedback
        if (isBlocking == true)
        {
            blockFeedbObject.SetActive(true);
        }
        else
        {
            blockFeedbObject.SetActive(false);
        }
    }

    public void StunPlayer()
    {
        isStunned = true;
        StartCoroutine("StartStunEffect");
    }

    IEnumerator StartStunEffect()
    {
        yield return new WaitForSeconds(stunDelay);
        stunDelay = 0.0f;
        isStunned = false;
    }
}
