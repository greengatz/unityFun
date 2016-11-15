using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class progress : MonoBehaviour {

    [System.Serializable]
    public struct namedPrefab
    {
        public string name;
        public GameObject prefab;
    }

    public State initialState;
    public static State currentState;
    public GameObject[] allies;
    public GameObject[] enemies;
    public Combatant test;
    public namedPrefab[] prefabs;

	// Use this for initialization
	void Start () {
        currentState = initialState;
        for(int i = 0; i < prefabs.Length; i++)
        {
            PrefabDict.set(prefabs[i].name, prefabs[i].prefab);
        }
	}
	
	// Update is called once per frame
	void Update () {
	    switch(currentState)
        {
            case State.BATTLE:
                battleState.update();
                if (battleState.currentState == BattleEnum.FINISHED)
                {
                    currentState = State.IDLE;
                }
                break;
            case State.WALKING:
                walking();
                break;
            case State.IDLE:
                break;
            default:
                Debug.Log("ERROR: default state case, should never be entered");
                break;
        }
	}

    private void walking()
    {
        Debug.Log("ERROR: currently in un-implemented Walking state");
        startBattle();
    }

    private void startBattle()
    {
        Debug.Log("Starting battle");

        ArrayList newAllies = new ArrayList();
        ArrayList newEnemies = new ArrayList();

        foreach(GameObject obj in allies) {
            newAllies.Add(obj.GetComponent<Combatant>());
        }
        foreach (GameObject obj in enemies)
        {
            newEnemies.Add(obj.GetComponent<Combatant>());
        }


        battleState.newBattle(newAllies, newEnemies);
        currentState = State.BATTLE;
    }

    public void setState(State newState)
    {
        currentState = newState;
    }

    public State getState()
    {
        return currentState;
    }
}
