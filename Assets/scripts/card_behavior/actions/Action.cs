using UnityEngine;
using System.Collections;

public interface Action {

    // does whatever the character is supposed to do
    void execute();
    bool isFinished();
    void report(Object obj);
}
