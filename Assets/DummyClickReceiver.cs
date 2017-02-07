using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyClickReceiver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        Debug.Log("clicked");
    }

    void OnMouseOver()
    {
        Debug.Log("start hover");
    }

    void OnMouseExit()
    {
        Debug.Log("exit hover");
    }
}
