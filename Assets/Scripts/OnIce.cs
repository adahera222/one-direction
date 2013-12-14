﻿using UnityEngine;
using System.Collections;

public class OnIce : MonoBehaviour {

    public bool onIce = true;
    public ParticleSystem splash;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Ice")
        {
            EffectsScript.Instance.Splash(transform.position);
            onIce = false;
            Destroy(gameObject);
            updateScore();
            checkGameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Hole")
        {
            EffectsScript.Instance.Splash(transform.position);
            onIce = false;
            Destroy(gameObject);

            updateScore();
            checkGameOver();

        }
    }

    void updateScore()
    {
        if (gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy died");
            Score score = GameObject.Find("Score").GetComponent<Score>();
            score.score += 100;
        }
    }

    void checkGameOver()
    {
        if (gameObject.tag == "Player")
        {
            Debug.Log("Player Died - Game Over");
            Application.LoadLevel("Menu");
            StartCoroutine("ReloadGame");
        }

    }

    IEnumerable ReloadGame()
    {
        yield return new WaitForSeconds(2);

        Application.LoadLevel("Level1");
    }
}
