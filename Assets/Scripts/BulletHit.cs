using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

    private float force = 0;
    private Vector2 direction;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ice") return;
        BulletScript bullet = collider.gameObject.GetComponent<BulletScript>();
        if (bullet != null)
        {
            MoveScript move = collider.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {
                force = bullet.force;
                direction = move.direction.normalized;
                rigidbody2D.AddForce(direction * force);
                SoundHelper.Instance.MakeHitSound();
            }
            Destroy(bullet.gameObject);
            force = 0;
            direction = Vector2.zero;
        }
    }

}
