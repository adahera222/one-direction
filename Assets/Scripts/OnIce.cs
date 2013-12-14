using UnityEngine;
using System.Collections;

public class OnIce : MonoBehaviour {

    public bool onIce = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name == "ice")
        {
            onIce = false;
            Destroy(gameObject);
        }
    }
}
