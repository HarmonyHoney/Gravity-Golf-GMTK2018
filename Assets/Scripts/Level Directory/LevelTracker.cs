using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTracker : MonoBehaviour {

    private static int currentWorld;

    private static int currentLevel;

    public static int CurrentWorld {

        get {
            return currentWorld;
        }
        set {
            currentWorld = value;
        }
    }

    public static int CurrentLevel {

        get {
            return currentLevel;
        }
        set {
            currentLevel = value;
        }
    }

}
