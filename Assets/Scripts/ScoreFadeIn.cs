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

    [SerializeField] private RectTransform restartTransform;

    private float offsetY;

    private void Start() {

        rectTransform = GetComponent<RectTransform>();

        offsetY = rectTransform.anchoredPosition3D.y - restartTransform.anchoredPosition3D.y;

    }

    private void Update() {

        totalTime += Time.deltaTime;

        rectTransform.anchoredPosition3D = Vector3.Lerp(startPosition, targetPosition, totalTime / fadeTime);

        restartTransform.anchoredPosition3D = new Vector3(restartTransform.anchoredPosition3D.x, rectTransform.anchoredPosition3D.y - offsetY, restartTransform.anchoredPosition3D.z);


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
