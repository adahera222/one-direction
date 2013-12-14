using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    public  float speed = 5;

    private Vector2 movement;

	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxis("Horizontal");// > 0 ? 1 :0;

        movement = new Vector2(speed * inputX, 0f);

        Vector2 pos2d = new Vector2(transform.position.x, transform.position.y);
        Vector3 currentPosition = transform.position;
        currentPosition.z = 0;

        Vector3 direction = rigidbody2D.velocity.normalized;
        Vector3 newPosition = currentPosition + direction;
        newPosition.z = 10;

        float angle = Mathf.Atan2(newPosition.x - currentPosition.x, newPosition.y - currentPosition.y) * Mathf.Rad2Deg;
        Vector3 rotation = new Vector3(0, 0, angle);
        transform.LookAt(newPosition, Vector3.back);// = Quaternion.Euler(rotation);
        
	}

    void FixedUpdate()
    {
        //rigidbody2D.velocity = movement;
        float angle = (Camera.main.transform.rotation.eulerAngles.z) * Mathf.Deg2Rad;
        Vector2 g = new Vector2(Mathf.Sin(angle), -Mathf.Cos(angle));
        //Debug.Log("Angle: " + gravity.rotation.eulerAngles.z + " Gravity:" + g.ToString());

        rigidbody2D.AddForce(g);
    }

}
