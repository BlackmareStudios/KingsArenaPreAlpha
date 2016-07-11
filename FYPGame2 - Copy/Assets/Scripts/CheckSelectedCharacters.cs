using UnityEngine;
using System.Collections;

public class CheckSelectedCharacters : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;

    // Character movement speed
    public float character1MovementSpeed;
    public float character2MovementSpeed;

    public GameObject p1GameObj;
    // Change player's movement speed depending on what character they chose
    public BasicPlayerMovement player1MovementScript;

    public GameObject p2GameObj;
    // Change player's movement speed depending on what character they chose
    public BasicPlayerMovement player2MovementScript;

    // Use this for initialization
    void Start () {
        Load();

        player1 = GameObject.Find("P1AttackRange");
        player2 = GameObject.Find("P2AttackRange");

        character1MovementSpeed = 6.0f;
        character2MovementSpeed = 5.5f;

        p1GameObj = GameObject.Find("Player1");
        player1MovementScript = p1GameObj.GetComponent<BasicPlayerMovement>();

        p2GameObj = GameObject.Find("Player2");
        player2MovementScript = p2GameObj.GetComponent<BasicPlayerMovement>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Load();
        }

        if (player1 != null && player2 != null)
        {
            // Check which character player 1 chose
            switch (StoredInfo.player1PickNumber)
            {
                case 1:
                    print("Player 1 picked character 1");
                    // Disable other character script if player chose to use player 1
                    player1.GetComponent<Character2>().enabled = false;
                    player1MovementScript.movementSpeed = character1MovementSpeed;
                    break;
                case 2:
                    print("Player 1 picked character 2");
                    // Disable other character script if player chose to use player 2
                    player1.GetComponent<Character1>().enabled = false;
                    player1MovementScript.movementSpeed = character2MovementSpeed;
                    break;
                case 3:
                    print("Player 1 picked character 3");
                    break;
                case 4:
                    print("Player 1 picked character 4");
                    break;
            }
        }
        
        // Check which character player 2 chose
        switch (StoredInfo.player2PickNumber)
        {
            case 1:
                print("Player 2 picked character 1");
                // Disable other character script if player chose to use player 1
                player2.GetComponent<Character2>().enabled = false;
                player2MovementScript.movementSpeed = character1MovementSpeed;
                break;
            case 2:
                print("Player 2 picked character 2");
                // Disable other character script if player chose to use player 2
                player2.GetComponent<Character1>().enabled = false;
                player2MovementScript.movementSpeed = character2MovementSpeed;
                break;
            case 3:
                print("Player 2 picked character 3");
                break;
            case 4:
                print("Player 2 picked character 4");
                break;
        }
    }

    void Load()
    {
        StoredInfo.player1PickNumber = PlayerPrefs.GetInt("Player1PickNumber", StoredInfo.player1PickNumber);
        StoredInfo.player2PickNumber = PlayerPrefs.GetInt("Player2PickNumber", StoredInfo.player2PickNumber);
    }
}
