using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private Text text;

    //[HideInInspector] public int strokes;

    private void Start() {

        text = GetComponent<Text>();
    }

    public void UpdateScore(int strokes) {

        text.text = strokes + " STROKES";

    }
}
