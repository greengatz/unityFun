using UnityEngine;
using System.Collections;

public class Challenger : MonoBehaviour, TeamOwner {

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

    public void OnMouseDown()
    {
        if(progress.currentState == State.IDLE)
        {
            progress.getInstance().chooseOpponent(this.gameObject);
        }
    }
}
