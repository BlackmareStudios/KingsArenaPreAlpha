using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public bool isTouchingBlockNorth;
    public bool isTouchingBlockSouth;
    public bool isTouchingBlockEast;
    public bool isTouchingBlockWest;

    // Use this for initialization
    void Start () {
        isTouchingBlockNorth = false;
        isTouchingBlockSouth = false;
        isTouchingBlockEast = false;
        isTouchingBlockWest = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "BlockNorth")
        {
            isTouchingBlockNorth = true;
        }
        if (hit.gameObject.tag == "BlockSouth")
        {
            isTouchingBlockSouth = true;
        }
        if (hit.gameObject.tag == "BlockEast")
        {
            isTouchingBlockEast = true;
        }
        if (hit.gameObject.tag == "BlockWest")
        {
            isTouchingBlockWest = true;
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.tag == "BlockNorth")
        {
            isTouchingBlockNorth = false;
        }
        if (hit.gameObject.tag == "BlockSouth")
        {
            isTouchingBlockSouth = false;
        }
        if (hit.gameObject.tag == "BlockEast")
        {
            isTouchingBlockEast = false;
        }
        if (hit.gameObject.tag == "BlockWest")
        {
            isTouchingBlockWest = false;
        }
    }
}
