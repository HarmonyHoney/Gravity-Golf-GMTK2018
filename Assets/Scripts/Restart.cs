using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

    [SerializeField] private Transform fadeDiamond;

    private Transform score;
    private ChangeScene changeScene;

    private void Start() {

        changeScene = FindObjectOfType<ChangeScene>();

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
        changeScene.nextScene = SceneManager.GetActiveScene().name;
        //changeScene.LoadNextScene();

        FindObjectOfType<Ball>().canAct = false;

        Transform fade = Instantiate(fadeDiamond, Camera.main.transform);   //Instantiate fade out
        fade.GetComponent<FadeDiamond>().fadeIn = false;                    //Set fadeIn to false

        score.GetComponent<ScoreFadeIn>().enabled = true;
        score.GetComponent<ScoreFadeIn>().FadeOut();
    }
}
