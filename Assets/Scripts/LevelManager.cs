using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    public struct World
    {
        public string name;
        public List<string> levelIndex;
        public World(string _name)
        {
            levelIndex = new List<string>();
            name = _name;
        }
    }

    public int currentWorld = 0;
    public int currentLevel = 0;
    public bool isChange = false;

    public List<World> worldIndex;


    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
        SceneManager.LoadScene(worldIndex[currentWorld].levelIndex[currentLevel]);
    }

    public void Reset()
    {
        Load();
    }
    public void Next()
    {
        currentLevel++;

        if (currentLevel > worldIndex[currentWorld].levelIndex.Count - 1)
        {
            currentLevel = 0;
            currentWorld++;
        }
        if (currentWorld > worldIndex.Count - 1)
        {
            currentWorld = 0;
        }

        Load();
    }

}
