using UnityEngine;
using System.Collections;

public class CameraRotateScript : MonoBehaviour {

    float smooth = 2.0f;
    float tiltAngle = 30.0f;
    bool rotating = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
 
        if (Input.GetButtonDown("Rotate"))
        {
            transform.Rotate(Vector3.back, 90, 0);
        }      
	
	}



}
