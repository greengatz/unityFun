using UnityEngine;
using System.Collections;

public static class battleState {

    private static ArrayList allies;
    private static ArrayList enemies;
    // add list for enemies

    private static ArrayList actionQueue;
    private static Action currentAction;

    public static BattleEnum currentState;

    public static Selectable currentSelection;

    public static void newBattle(ArrayList newAllies, ArrayList newEnemies)
    {
        allies = newAllies;
        enemies = newEnemies;
        currentState = BattleEnum.ACCEPTING_INPUT;
        currentSelection = null;
    }

    public static void update()
    {
        switch(currentState)
        {
            case BattleEnum.ACCEPTING_INPUT:

                bool actionsReady = true;
                foreach(Combatant ally in allies)
                {
                    actionsReady = actionsReady && ally.isActionChosen();
                }

                if (actionsReady)
                {
                    calculateEnemyMoves();
                    currentState = BattleEnum.PREPARING_ATTACKS;
                }
                break;

            case BattleEnum.PREPARING_ATTACKS:
                prepareAttacks();
                break;

            case BattleEnum.WAITING_FOR_ANIMATIONS:
                executeMoves();
                break;

            default:
                break;
        }
    }

    private static void calculateEnemyMoves()
    {
        // TODO
    }

    // takes the inputs from combatants and prepares the attack queue
    private static void prepareAttacks()
    {
        Debug.Log("PREPARING QUEUE");

        actionQueue = new ArrayList();
        foreach (Combatant ally in allies)
        {
            actionQueue.Add(ally.getAction());
        }

        foreach (Combatant enemy in enemies)
        {
            actionQueue.Add(enemy.getAction());
        }

        currentState = BattleEnum.WAITING_FOR_ANIMATIONS;

        // TODO reorder
    }

    private static void executeMoves()
    {
        if (currentAction == null || currentAction.isFinished()) {
            if (actionQueue.Count > 0)
            {
                currentAction = (Action) actionQueue[0];
                actionQueue.RemoveAt(0);
                currentAction.execute();
            } else
            {
                Debug.Log("ROUND OVER");
                if (isBattleOver())
                {
                    currentState = BattleEnum.FINISHED;
                }
                else
                {
                    currentState = BattleEnum.ACCEPTING_INPUT;
                }
            }
        }
    }

    private static bool isBattleOver()
    {
        if (allies.Count == 0)
        {
            Debug.Log("enemies win!");
            foreach(Combatant enemy in enemies)
            {
                Object.Destroy(((MonoBehaviour) enemy).gameObject);
            }
            return true;
        } else if (enemies.Count == 0)
        {
            Debug.Log("allies win!");
            foreach (Combatant ally in allies)
            {
                Object.Destroy(((MonoBehaviour) ally).gameObject);
            }
            return true;
        }
        return false;
    }

    public static void removeFromBattle(Combatant toRemove)
    {
        if (allies.Contains(toRemove))
        {
            allies.Remove(toRemove);
        } else
        {
            enemies.Remove(toRemove);
        }
    }

    public static ArrayList getAllies()
    {
        return allies;
    }

    public static ArrayList getEnemies()
    {
        return enemies;
    }

    public static void select(Combatant target)
    {
        if(currentSelection != null)
        {
            currentSelection.setTarget(target);
        }
    }
}
