using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
    public int damage = 0;
    public float force = 10;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5);
	}



}
