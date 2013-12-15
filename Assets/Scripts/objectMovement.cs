using UnityEngine;
using System.Collections;

public class objectMovement : MonoBehaviour {

    public float maxSpeed = 5;

    private Vector2 nudge = new Vector2(0, 0);
    private int random;

    void Start()
    {
        random = Random.Range(80, 120);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos2d = new Vector2(transform.position.x, transform.position.y);
        Vector3 currentPosition = transform.position;
        currentPosition.z = 0;

        Vector3 direction = rigidbody2D.velocity.normalized;
        Vector3 newPosition = currentPosition + direction;
        newPosition.z = 10;

        float angle = Mathf.Atan2(newPosition.x - currentPosition.x, newPosition.y - currentPosition.y) * Mathf.Rad2Deg;
        Vector3 rotation = new Vector3(0, 0, angle);
        transform.LookAt(newPosition, Vector3.back);// = Quaternion.Euler(rotation);

        if (Input.GetMouseButtonDown(0))
        {
            nudge = new Vector2(50, 0);
        }
        else
        {
            nudge = Vector2.zero;
        }



    }

    void FixedUpdate()
    {
        float angle = (Camera.main.transform.rotation.eulerAngles.z)*Mathf.Deg2Rad;
        Vector2 g = new Vector2(Mathf.Sin( angle), -Mathf.Cos(angle));
        rigidbody2D.AddForce(g*random/100);
        Vector3 spin = Vector3.zero;
        spin.z = Random.Range(0,20);
        transform.Rotate(spin);
    }
}
