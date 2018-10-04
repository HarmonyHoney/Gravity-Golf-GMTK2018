using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDirectory : MonoBehaviour {

    
    public Object[] worldOne;
    public Object[] worldTwo;
    public Object[] worldThree;


    public Object[] WorldArray(int world) {

        Object[] worldArray;

        switch (world) {

            default:
                worldArray = worldOne;
                break;

            case 1:
                worldArray = worldTwo;
                break;

            case 2:
                worldArray = worldThree;
                break;

        }

        return worldArray;
    }

    public string LevelToString (int world, int level) {

        Object[] worldArray = WorldArray(world);

        return worldArray[level].name;

    }

    public void SetNextLevel() {

        Object[] worldArray = WorldArray(LevelTracker.CurrentWorld);

        LevelTracker.CurrentLevel++;

        if (LevelTracker.CurrentLevel + 1 > worldArray.Length) {            //Add functionality to return to level select screen when world is complete

            LevelTracker.CurrentWorld++;

            LevelTracker.CurrentLevel = 0;
        }

        Debug.Log("World: " + (LevelTracker.CurrentWorld + 1) + ", Level: " + (LevelTracker.CurrentLevel + 1));
    }

}
