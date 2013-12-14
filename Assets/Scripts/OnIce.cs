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
            onIce = false;
            Destroy(gameObject);
            if (gameObject.name == "player")
            {
                Debug.Log("Game Over");
            }
            updateScore();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Hole")
        {
            EffectsScript.Instance.Splash(transform.position);
            onIce = false;
            Destroy(gameObject);
            if (gameObject.name == "player")
            {
                Debug.Log("Game Over");
            }
            updateScore();

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
}
