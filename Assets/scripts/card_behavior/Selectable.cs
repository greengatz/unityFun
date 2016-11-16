using UnityEngine;
using System.Collections;

public interface Selectable {

    // BY LAW, ATTACKER MUST BE SET ON INSTANTIATION. GOT IT? DO IT. OR ELSE.
    void setSource(AlliedCombatant source);

    void setTarget(Combatant target);

    bool isSelected();
}
