using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LevelTool : MonoBehaviour
{
	[System.Serializable]
	public struct World
	{
		public string name;
		public List<Object> levelIndex;
	}

	LevelManager lm;
	public bool isAct = false;
	public List<World> worldIndex;

	// Use this for initialization
	void Start ()
	{
		lm = GetComponent<LevelManager>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isAct)
		{
			isAct = false;
			lm.worldIndex.Clear();

			int i = 0;
			foreach(World w in worldIndex)
			{
				lm.worldIndex.Add(new LevelManager.World(w.name));
				foreach(Object o in w.levelIndex)
				{
					lm.worldIndex[i].levelIndex.Add(o.name);
				}
				i++;
			}
		}
	}
}
