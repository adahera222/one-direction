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
        Vector3 hurtForce = transform.position - enemy.position + Vector3.up*100;
        rigidbody2D.AddForce(hurtForce);
        SoundHelper.Instance.MakePenguinHitSound();
    }
}
