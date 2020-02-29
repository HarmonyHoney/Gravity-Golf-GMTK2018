using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] private Transform finishParticleSystem;
    [SerializeField] private Transform holeComplete;
    [SerializeField] private Transform fadeDiamond;
    [SerializeField] private Transform swapFX;

    [SerializeField] private Transform jumpAudio;
    [SerializeField] private Transform loseAudio;
    [SerializeField] private Transform collideAudio;

    [SerializeField] private float collideMinimumPitch;

    private AudioSource collideAudioSource;

    private Transform canvas;
    private Score score;
    private Restart restart;

    //[SerializeField] private string nextScene;

    private Rigidbody2D rb2d;

    private Animator anim;

    [HideInInspector] public bool canAct = true;

    [HideInInspector] public int strokes;


    

	private void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        canvas = FindObjectOfType<Canvas>().transform;
        score = FindObjectOfType<Score>();
        restart = FindObjectOfType<Restart>();
        anim = GetComponent<Animator>();


        collideAudioSource = collideAudio.GetComponent<AudioSource>();

        Instantiate(fadeDiamond, Camera.main.transform);


	}
	

	private void Update () {
		
        if ( (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && canAct) {

            rb2d.gravityScale = -rb2d.gravityScale;

            strokes++;

            score.UpdateScore(strokes);

            jumpAudio.GetComponent<AudioSource>().Play();

            Instantiate(swapFX, transform.position, Quaternion.Euler(Vector3.zero), null);
            anim.SetTrigger("swap");
        }

	}


    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.tag == "Finish" && canAct) {

            FinishLevel();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.gameObject.tag == "Respawn" && canAct) {
            canAct = false;
            restart.RestartScene();
            loseAudio.gameObject.SetActive(true);
        }

        /*if (Mathf.Abs(rb2d.velocity.x) > 3f || Mathf.Abs(rb2d.velocity.y) > 3f) {

            collideAudio.GetComponent<AudioSource>().Play();
        }*/


        collideAudioSource.pitch = (Mathf.Abs(rb2d.velocity.x) + Mathf.Abs(rb2d.velocity.y)) / 10f;

        if (collideAudioSource.pitch > collideMinimumPitch) {
            collideAudioSource.Play();
        }
        



    }


    void FinishLevel() {

        canAct = false;

        Transform particleSystem = Instantiate(finishParticleSystem, transform.position, Quaternion.Euler(Vector3.zero), null);     //Instantiate Particle System
        particleSystem.GetComponent<FollowObject>().followTransform = this.transform;                                               //Particle system will follow this transform

        Instantiate(holeComplete, canvas);

        ScoreCard.TotalScore += strokes;
        Debug.Log("Score Card: " + ScoreCard.TotalScore);

    }
}
