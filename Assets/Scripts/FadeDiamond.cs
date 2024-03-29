﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeDiamond : MonoBehaviour
{

    public bool fadeIn;

    private float totalTime;
    [SerializeField] float fadeTime;

    private Camera cameraMain;

    private Vector3 scaleRatio = new Vector3(6f, 5f, 1f);
    private Vector3 scaleZero = new Vector3(0f, 0f, 1f);

    private Vector3 startScale;
    private Vector3 targetScale;

    [SerializeField] public bool restartScene;


    private void Start()
    {

        cameraMain = Camera.main;

        if (fadeIn) {

            startScale = scaleRatio * cameraMain.orthographicSize;

            targetScale = scaleZero;
        }
        else {
            startScale = scaleZero;

            targetScale = scaleRatio * cameraMain.orthographicSize;
        }

        transform.localScale = startScale;

    }

    private void Update()
    {

        totalTime += Time.deltaTime;

        transform.localScale = Vector3.Lerp(startScale, targetScale, totalTime / fadeTime);


        if (transform.localScale == targetScale)
        {

            if (fadeIn)
            {
                Destroy(gameObject);
            }
            else
            {
                if (restartScene)
                {
                    FindObjectOfType<LevelManager>().Reset();
                }
                else
                {
                    FindObjectOfType<LevelManager>().Next();
                }
            }
            
        }

    }

}
