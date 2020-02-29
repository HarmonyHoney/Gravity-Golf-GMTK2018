using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LevelTool : MonoBehaviour
{
	LevelManager lm;

	public bool isAct = false;
	public Object[] worldOne;

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

			lm.worldIndex.Add(new LevelManager.World("World 1"));
			foreach (Object o in worldOne)
			{
				lm.worldIndex[0].levelIndex.Add(o.name);
			}

		}
	}
}
