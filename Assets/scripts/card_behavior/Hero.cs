using UnityEngine;
using System.Collections;

[System.Serializable]
public class Hero {

    public bool isAlly = true;
    public GameObject obj;

    // TODO make that a class that does shit
    public GameObject[] deck;

    public GameObject spawnHero()
    {
        GameObject toRet = GameObject.Instantiate(obj);
        if(isAlly)
        {
            toRet.GetComponent<AlliedCombatant>().options = deck;
        }

        return toRet;
    }
}
