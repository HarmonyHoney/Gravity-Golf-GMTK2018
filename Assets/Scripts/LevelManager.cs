using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int currentWorld = 0;
    public int currentLevel = 0;
    public bool isChange = false;


    
    public Object[] worldOne;
    public Object[] worldTwo;
    public Object[] worldThree;


    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public Object[] WorldArray(int world)
    {

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

    public void Update()
    {
        if (isChange)
        {
            isChange = false;
            Load();
        }
    }

    public void Load()
    {
        SceneManager.LoadScene(currentLevel + 1);
    }



    public string LevelToString (int world, int level)
    {

        Object[] worldArray = WorldArray(world);

        return worldArray[level].name;

    }

}
