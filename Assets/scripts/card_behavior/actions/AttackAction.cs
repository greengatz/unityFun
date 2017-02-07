using UnityEngine;
using System.Collections;

public class AttackAction : Action {

    private Combatant attacker;
    private Combatant target;

    private int damage;

    public bool isExecuting = false;


    public AttackAction(Combatant attacker, Combatant target, int damage)
    {
        this.attacker = attacker;
        this.target = target;
        this.damage = damage;
    }

	public void execute()
    {
        if(((MonoBehaviour)target) == null || ((MonoBehaviour)attacker) == null)
        {
            Debug.Log("invalid attack, someone died");
            return;
        }

        isExecuting = true;
        Debug.Log(attacker.getName() + " attacks " + target.getName() + " for " + damage + " damage!");

        Object proj = Object.Instantiate(PrefabDict.get("arrow"), ((MonoBehaviour)attacker).gameObject.transform.position + Vector3.up * 0.3f,
                                        //((MonoBehaviour)attacker).gameObject.transform.rotation);
                                        Quaternion.LookRotation(Vector3.up));

        Projectile actual = ((GameObject)proj).GetComponent<Projectile>();
        actual.initialize(this, target, 0.3f, 100f);
        actual.setAccels(0.2f, 100f, 1f);
    }

    // used to block the attack queue till it's done
    public bool isFinished()
    {
        return !isExecuting;
    }

    public void report(Object obj)
    {
        isExecuting = false;
        target.adjustHealth(-1 * damage);
        Object.Destroy(((MonoBehaviour) obj).gameObject);
    }
}
