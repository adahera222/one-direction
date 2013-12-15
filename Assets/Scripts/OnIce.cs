using UnityEngine;
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
            SoundHelper.Instance.MakeSplashSound();
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
            SoundHelper.Instance.MakeSplashSound();
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
            SpawnController.Instance.killEnemy();
        }
    }

    void checkGameOver()
    {
        if (gameObject.tag == "Player")
        {
            Debug.Log("Game Over");
            var gui = GameObject.FindObjectOfType<GameOver>() as GameOver;
            gui.activate();

            
        }

    }

}
