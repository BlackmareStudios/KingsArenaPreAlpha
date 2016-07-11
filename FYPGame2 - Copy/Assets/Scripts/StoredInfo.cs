using UnityEngine;
using System.Collections;

public class StoredInfo
{
    public static int player1PickNumber = 0;
    public static int player2PickNumber = 0;

    public static void DeleteAll()
    {
        // Clear what the players have picked as their character
        player1PickNumber = 0;
        player2PickNumber = 0;
    }
}