using UnityEngine;
using System.Collections;

public class AlliedCombatant : MonoBehaviour, Combatant {

    bool actionChosen = false;
    private int health;
    public int maxHealth = 6;
    public string name = "defaultAlly";
    public int attackVal = 2;

    private Action nextAction;

    public float waitingPeriod = 2f;
    private float waitTime;

    private bool hasDisplayedOptions = false;

    public float spaceBetweenCards = 0.08f;

    public GameObject[] options;
    private ArrayList instantiatedCards;

	void Start () {
        actionChosen = false;
        waitTime = waitingPeriod;
        health = maxHealth;
	}
	
	void Update () {
        // for the allied combatants, this is where we will get our input
        if(progress.currentState == State.BATTLE && battleState.currentState == BattleEnum.ACCEPTING_INPUT 
            && hasDisplayedOptions == false && actionChosen == false)
        {
            showCards();
        }
	}

    private void showCards()
    {
        Debug.Log("DISPLAYING ACTIONS FOR " + name);
        instantiatedCards = new ArrayList();
        for (int i = 0; i < options.Length; i++)
        {
            GameObject spawned = (GameObject) Object.Instantiate(options[i], this.gameObject.transform.position + Vector3.up * 0.3f + Vector3.forward * spaceBetweenCards * i
                                                                            + Vector3.back * spaceBetweenCards * options.Length / 2, this.gameObject.transform.rotation);

            instantiatedCards.Add(spawned);
            Selectable spawnedCast = spawned.GetComponent<Selectable>();
            spawnedCast.setSource(this);
        }
        hasDisplayedOptions = true;
    }

    public void setAction(Action chosen)
    {
        foreach (Object card in instantiatedCards) {
            if (card != null)
            {
                Object.Destroy(((GameObject)card));
            }
        }
        actionChosen = true;
        nextAction = chosen;
    }

    public Action getAction()
    {
        Action ret = nextAction;
        clearAction();
        return ret;
    }

    public bool isActionChosen()
    {
        return actionChosen;
    } 

    public void clearAction()
    {
        actionChosen = false;
        hasDisplayedOptions = false;
        waitTime = waitingPeriod;
    }

    public void adjustHealth(int change)
    {
        health += change;
        Debug.Log("Health is now " + health);

        if (health <= 0)
        {
            battleState.removeFromBattle(this);
            GameObject.Destroy(this.gameObject);
        }
    }

    public string getName()
    {
        return name;
    }

    public bool isDead()
    {
        return health <= 0;
    }
}
