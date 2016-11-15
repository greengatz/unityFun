using UnityEngine;
using System.Collections;

public class Decay : MonoBehaviour {

    public float totalTime = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        totalTime -= Time.deltaTime;

        if(totalTime <= 0)
        {
            Object.Destroy(this.gameObject);
        }
	}
}
