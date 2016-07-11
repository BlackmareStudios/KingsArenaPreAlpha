using UnityEngine;
using System.Collections;

public class BridgeController : MonoBehaviour {

    public GameObject bridgePrefab;

	// Use this for initialization
	void Start ()
    {
        Spawn();
    }
	
	// Update is called once per frame
	void Spawn ()
    {
        if (GameObject.Find("Bridge1") == null)
        {
            GameObject instantiatedProjectile = Instantiate(bridgePrefab, new Vector3(3.06f, -0.11f, -0.87f), Quaternion.Euler(0, -10, 0)) as GameObject;
            instantiatedProjectile.gameObject.name = "Bridge1";
        }

        if (GameObject.Find("Bridge2") == null)
        {
            GameObject instantiatedProjectile2 = Instantiate(bridgePrefab, new Vector3(-0.05f, -0.11f, -1.42f), Quaternion.Euler(0, -10, 0)) as GameObject;
            instantiatedProjectile2.gameObject.name = "Bridge2";
        }

        if (GameObject.Find("Bridge3") == null)
        {
            GameObject instantiatedProjectile3 = Instantiate(bridgePrefab, new Vector3(-3.1f, -0.11f, -1.96f), Quaternion.Euler(0, -10, 0)) as GameObject;
            instantiatedProjectile3.gameObject.name = "Bridge3";
        }
    }

    public void SpawnDelay()
    {
        StartCoroutine("StartSpawDelay");
    }

    IEnumerator StartSpawDelay()
    {
        yield return new WaitForSeconds(2.0f);
        Spawn();
    }
}
