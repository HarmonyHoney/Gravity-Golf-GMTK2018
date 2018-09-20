using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreFadeIn : MonoBehaviour {

    private RectTransform rectTransform;

    private float totalTime;
    [SerializeField] float fadeTime;

    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 targetPosition;

    private void Start() {

        rectTransform = GetComponent<RectTransform>();

    }

    private void Update() {

        totalTime += Time.deltaTime;

        rectTransform.anchoredPosition3D = Vector3.Lerp(startPosition, targetPosition, totalTime / fadeTime);


        if (rectTransform.anchoredPosition3D == targetPosition) {

            enabled = false;
        }

    }

    public void FadeOut() {

        targetPosition = startPosition;
        startPosition = rectTransform.anchoredPosition3D;

        totalTime = 0;
    }
}
