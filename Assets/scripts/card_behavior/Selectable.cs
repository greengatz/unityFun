using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour {

    public bool isSelected;
    public int damage = 2;

    public AlliedCombatant source;

	// Use this for initialization
	void Start () {
        isSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
	    // TODO make these rotate towards the camera
	}

    // BY LAW, ATTACKER MUST BE SET ON INSTANTIATION. GOT IT? DO IT. OR ELSE.
    public void setAttacker(AlliedCombatant source)
    {
        this.source = source;
    }

    public void target(Combatant target)
    {
        if (source == null)
        {
            Debug.Log("Trying to set attack with no source!");
        }
        source.setAction(new AttackAction(source, target, damage));
        Object.Destroy(this.gameObject);
    }

    void OnMouseDown()
    {
        battleState.currentSelection = this;
    }
}
