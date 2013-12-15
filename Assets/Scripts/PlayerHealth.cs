using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Bump(col.transform);
        }
    }

    void Bump(Transform enemy)
    {
        Debug.Log("Bump");
        Vector3 hurtForce = transform.position - enemy.position;
        rigidbody2D.AddForce(Camera.main.transform.rotation*hurtForce*100);
        SoundHelper.Instance.MakePenguinHitSound();
    }
}
