using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterSelectionScript : MonoBehaviour {
    public int player1PickNumber;
    public int player2PickNumber;

    public Sprite character1, character2;

    public Image playerOneSelection;
    public Image playerTwoSelection;

    // Use this for initialization
    void Start () {
        player1PickNumber = 1;
        player2PickNumber = 1;

        // Reset all the previously selected characters
        Reset();
    }
	
	// Update is called once per frame
	void Update () {
        //print(playerPickNumber);
        //print(this.gameObject.name);

        // Player 1 Picking Character
        if (Input.GetKeyDown(KeyCode.S))
        {
            player1PickNumber += 1;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            player1PickNumber -= 1;
        }
        // Make sure the pick number doesn't go more than the maximum (2)
        if (player1PickNumber > 2)
        {
            player1PickNumber = 1;
        }
        // Make sure the pick number doesn't go less than minimum (1)
        if (player1PickNumber < 1)
        {
            player1PickNumber = 2;
        }

        switch (player1PickNumber)
        {
            case 1:
                playerOneSelection.GetComponent<Image>().sprite = character1;
                break;
            case 2:
                playerOneSelection.GetComponent<Image>().sprite = character2;
                break;
            /*
            case 3:
                playerOneSelection.GetComponent<Image>().sprite = character3;
                break;
            case 4:
                playerOneSelection.GetComponent<Image>().sprite = character4;
                break;
            */
        }

        // Player 2 Picking Character
        if (Input.GetKeyDown(KeyCode.K))
        {
            player2PickNumber += 1;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            player2PickNumber -= 1;
        }
        // Make sure the pick number doesn't go more than the maximum (2)
        if (player2PickNumber > 2)
        {
            player2PickNumber = 1;
        }
        // Make sure the pick number doesn't go less than minimum (1)
        if (player2PickNumber < 1)
        {
            player2PickNumber = 2;
        }

        switch (player2PickNumber)
        {
            case 1:
                playerTwoSelection.GetComponent<Image>().sprite = character1;
                break;
            case 2:
                playerTwoSelection.GetComponent<Image>().sprite = character2;
                break;
            /*
            case 3:
                playerTwoSelection.GetComponent<Image>().sprite = character3;
                break;
            case 4:
                playerTwoSelection.GetComponent<Image>().sprite = character4;
                break;
            */
        }
    }

    void Reset()
    {
        StoredInfo.DeleteAll();
        PlayerPrefs.DeleteAll();
    }

    // Arena Select
    public void ArenaSelectButton()
    {
        PlayerPrefs.SetInt("Player1PickNumber", player1PickNumber);
        PlayerPrefs.SetInt("Player2PickNumber", player2PickNumber);
        PlayerPrefs.Save(); // Writes all modified preferences to disk
        SceneManager.LoadScene("ArenaSelect");
    }

    // Player 1 selection button
    public void WButton()
    {
        player1PickNumber -= 1;
    }

    public void SButton()
    {
        player1PickNumber += 1;
    }

    // Player 2 selection button
    public void IButton()
    {
        player2PickNumber -= 1;
    }

    public void KButton()
    {
        player2PickNumber += 1;
    }
}
