using UnityEngine;
using System.Collections;

public class SpriteLookAtCamera : MonoBehaviour {
    //public Camera mainCamera;
    public Transform cameraTransform;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        /*
        // Look at the opposite of the camera
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward, mainCamera.transform.rotation * Vector3.up);
        */
        transform.LookAt(cameraTransform);
    }
}
