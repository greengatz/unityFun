using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour, TeamOwner {

    public Hero[] team;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Hero[] getTeam()
    {
        return team;
    }
}
