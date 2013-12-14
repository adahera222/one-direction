using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D collider)
    {
        BulletScript bullet = collider.gameObject.GetComponent<BulletScript>();
        if (bullet != null)
        {

            Destroy(bullet.gameObject); 
        }
    }

    void FixedUpdate()
    {
        MoveScript bullet = collider.gameObject.GetComponent<MoveScript>();
        if (bullet != null)
        {

            rigidbody2D.AddForce(bullet.direction);
        }
        
    }

}
