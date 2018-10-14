using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {

    [SerializeField] private Transform fadeDiamond;
    [SerializeField] private float clickRange;

    private Transform score;
    private RectTransform rectTransform;

    private void Start() {

        rectTransform = GetComponent<RectTransform>();

        score = FindObjectOfType<Score>().transform;

    }

    private void Update() {
        
        if (Input.GetMouseButtonDown(0)) {

            Vector3 mousePos = Input.mousePosition;

            if (Vector3.Distance(mousePos, rectTransform.position) < clickRange) {

                RestartScene();
            }   
            
        }
        else if (Input.GetKeyDown(KeyCode.R)) {
            RestartScene(); 
        }



    }

    public void RestartScene() {

        FindObjectOfType<Ball>().canAct = false;

        Transform fade = Instantiate(fadeDiamond, Camera.main.transform);   //Instantiate fade out
        fade.GetComponent<FadeDiamond>().restartScene = true;               //restartScene = true
        fade.GetComponent<FadeDiamond>().fadeIn = false;                    //fadeIn = false

        score.GetComponent<ScoreFadeIn>().enabled = true;
        score.GetComponent<ScoreFadeIn>().FadeOut();
    }
}
