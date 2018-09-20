using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleComplete : MonoBehaviour {

    [SerializeField] private Transform fadeDiamond;
    [SerializeField] private float smoothTime;
    [SerializeField] private float duration;
    [SerializeField] private float shrinkTime;

    private Transform score;

    private Vector3 targetSize = Vector3.one;
    private Vector3 currentVelocity;

    private bool actOnce = true;

    private void Start() {

        transform.localScale = Vector3.zero;

        score = FindObjectOfType<Score>().transform;
    }

    private void Update() {

        transform.localScale = Vector3.SmoothDamp(transform.localScale, targetSize, ref currentVelocity, smoothTime);

        duration = duration - Time.deltaTime;

        if (duration <= 0 && actOnce) {
            actOnce = false;

            targetSize = Vector3.zero;
            smoothTime = shrinkTime;

            Transform fade = Instantiate(fadeDiamond, Camera.main.transform);   //Instantiate fade out
            fade.GetComponent<FadeDiamond>().fadeIn = false;                    //Set fadeIn to false

            score.GetComponent<ScoreFadeIn>().enabled = true;
            score.GetComponent<ScoreFadeIn>().FadeOut();

        }
    }
}
