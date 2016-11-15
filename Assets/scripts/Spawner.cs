using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject toSpawn;
    public float frequency;

    float tillNextSpawn;

	// Use this for initialization
	void Start () {
        tillNextSpawn = frequency;
	}
	
	// Update is called once per frame
	void Update () {
        tillNextSpawn -= Time.deltaTime;

        if(tillNextSpawn <= 0)
        {
            Object.Instantiate(toSpawn, this.gameObject.transform.position, this.gameObject.transform.rotation);
            tillNextSpawn = frequency;
        }
	}
}
