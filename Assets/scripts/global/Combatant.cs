using UnityEngine;
using System.Collections;

public interface Combatant {
    bool isActionChosen();
    void clearAction();
    Action getAction();
    void adjustHealth(int change);
    string getName();
    bool isDead();
}
