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

    private static progress instance;

    public State initialState;
    public static State currentState;
    public Hero[] allies;
    public Hero[] enemies;
    public Combatant test;
    public namedPrefab[] prefabs;

    public GameObject player;
    private GameObject opponent;
    public GameObject tempOpp;

    public Vector3 allySpawnCenter = new Vector3(1.9f, 0.75f, -6.5f);
    public Vector3 enemySpawnCenter = new Vector3(0.75f, 0.75f, -6.5f);
    public float spaceBetweenDudes = 0.3f;

	// Use this for initialization
	void Start () {
        instance = this;
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
                idle();
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

    private void idle()
    {
        //chooseOpponent(tempOpp);
    }

    private void startBattle()
    {
        Debug.Log("Starting battle");

        ArrayList newAllies = new ArrayList();
        ArrayList newEnemies = new ArrayList();

        for(int i = 0; i < allies.Length; i++) {
            GameObject spawned = allies[i].spawnHero();
            spawned.transform.position = allySpawnCenter + new Vector3(0, 0, spaceBetweenDudes * i - spaceBetweenDudes * (allies.Length - 1f) / 2f);
            newAllies.Add(spawned.GetComponent<Combatant>());
        }
        for (int i = 0; i < enemies.Length; i++)
        {
            GameObject spawned = enemies[i].spawnHero();
            spawned.transform.position = enemySpawnCenter + new Vector3(0, 0, spaceBetweenDudes * i - spaceBetweenDudes * (enemies.Length - 1f) / 2f);
            newEnemies.Add(spawned.GetComponent<Combatant>());
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


    public void chooseOpponent(GameObject npc)
    {
        opponent = npc;
        allies = player.GetComponent<TeamOwner>().getTeam();
        enemies = npc.GetComponent<TeamOwner>().getTeam();
        startBattle();
    }

    public static progress getInstance()
    {
        return instance;
    }
}
