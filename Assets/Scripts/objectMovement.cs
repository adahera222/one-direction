using UnityEngine;
using System.Collections;

public class objectMovement : MonoBehaviour {

    public Vector2 speed = new Vector2(5,5);
    public Transform gravity;
    public float maxSpeed = 5;

    private Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        Vector2 pos2d = new Vector2(transform.position.x, transform.position.y);
        //transform.Rotate();
        //Vector2 direction = rigidbody2D.velocity.Normalize();
    }

    void FixedUpdate()
    {
        //rigidbody2D.velocity = movement;
        float angle = (gravity.rotation.eulerAngles.z)*Mathf.Deg2Rad;
        Vector2 g = new Vector2(Mathf.Sin( angle), -Mathf.Cos(angle));
        //Debug.Log("Angle: " +gravity.rotation.eulerAngles.z +" Gravity:"+g.ToString());


        rigidbody2D.AddForce(g);
        //rigidbody2D.velocity = g;
        
    }
}
