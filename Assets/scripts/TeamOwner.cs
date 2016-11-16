using UnityEngine;
using System.Collections;

/**
 * This is a player of the game. these methods allow the state to access get information from them about what to put on the board.
 */
public interface TeamOwner {

    Hero[] getTeam();
}
