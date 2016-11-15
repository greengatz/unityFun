using UnityEngine;
using System.Collections;

public class EnemyCombatant : MonoBehaviour, Combatant
{

    bool actionChosen = false;
    private int health;
    public int maxHealth = 5;
    public string name = "defaultEnemy";
    public int attackVal = 1;

    private Action nextAction;

    public float waitingPeriod = 2f;
    private float waitTime;

    // Use this for initialization
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextAction == null && battleState.currentState == BattleEnum.ACCEPTING_INPUT)
        {
            // we do it like this so we only get one action, but can have some time to make our decision
            ArrayList allies = battleState.getAllies();
            if (allies != null)
            {
                Combatant target = (Combatant)allies[Random.Range(0, allies.Count)];
                nextAction = new AttackAction(this, target, attackVal);
            }
        }
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

    public void clearAction()
    {
        nextAction = null;
        return; // doesn't apply to enemies since they don't lock in actions
    }

    public Action getAction()
    {
        Action temp = nextAction;
        clearAction();
        return temp;
    }

    public string getName()
    {
        return name;
    }

    public bool isActionChosen()
    {
        return true;
    }

    public bool isDead()
    {
        return health <= 0;
    }

    public void OnMouseDown()
    {
        battleState.select(this);
    }
}
