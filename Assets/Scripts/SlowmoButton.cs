using UnityEngine;
using System.Collections;

public class SlowmoButton : MonoBehaviour {

    public float rate = 0.3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("SlowMo")!=0)
        {
            Time.timeScale = 0.5f;
            
        }
        else { Time.timeScale = 1f; }

        Debug.Log(Time.timeScale);
	
	}
}
