using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelector : MonoBehaviour {
    public bool useVr = false;
    public GameObject staticCam;
    public GameObject cameraParent;

    // Use this for initialization
    void Start () {
        if (useVr == false)
        {
            Debug.Log("Headset camera not present, switching to static camera");
            GameObject.Destroy(cameraParent);
        }
        else 
        {
            Debug.Log("Headset camera detected, launching");
            GameObject.Destroy(staticCam);
        }
	}
}
