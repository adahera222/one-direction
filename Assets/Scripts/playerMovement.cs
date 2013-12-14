using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    public  float speed = 5;
    public Transform gravity;

    private Vector2 movement;

	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxis("Horizontal");// > 0 ? 1 :0;

        movement = new Vector2(speed * inputX, 0f);
        
	}

    void FixedUpdate()
    {
        //rigidbody2D.velocity = movement;
        float angle = (gravity.rotation.eulerAngles.z) * Mathf.Deg2Rad;
        Vector2 g = new Vector2(Mathf.Sin(angle), -Mathf.Cos(angle));
        //Debug.Log("Angle: " + gravity.rotation.eulerAngles.z + " Gravity:" + g.ToString());

        rigidbody2D.AddForce(g);
    }

}
