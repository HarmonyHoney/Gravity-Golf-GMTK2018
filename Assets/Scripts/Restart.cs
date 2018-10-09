using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {

    [SerializeField] private Transform fadeDiamond;

    private Transform score;

    private void Start() {

        score = FindObjectOfType<Score>().transform;

    }

    private void Update() {
        
        if (Input.GetMouseButtonDown(0)) {

            Vector3 mousePos = Input.mousePosition;

            if (mousePos.x > 1200 && mousePos.y > 630) {

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
