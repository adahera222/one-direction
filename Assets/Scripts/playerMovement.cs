using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	// Update is called once per frame
	void Update () {

        Vector2 pos2d = new Vector2(transform.position.x, transform.position.y);
        Vector3 currentPosition = transform.position;
        currentPosition.z = 0;

        Vector3 direction = rigidbody2D.velocity.normalized;
        Vector3 newPosition = currentPosition + direction;
        newPosition.z = 10;

        transform.LookAt(newPosition, Vector3.back);
        
	}

    void FixedUpdate()
    {
        float angle = (Camera.main.transform.rotation.eulerAngles.z) * Mathf.Deg2Rad;
        Vector2 g = new Vector2(Mathf.Sin(angle), -Mathf.Cos(angle));
        rigidbody2D.AddForce(g);
    }

}
