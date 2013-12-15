using UnityEngine;
using System.Collections;

public class snowballThrower : MonoBehaviour {

    public Transform snowBall;
    public int fireRate = 2;

    private Vector3 mousePos;
    private Vector3 objectPos;
    private int cooldown = 0;

    void Update()
    {
        if(Input.GetButtonDown("Fire") && cooldown<0)
        {
            var shotTransform = Instantiate(snowBall) as Transform;
            shotTransform.position = transform.position;

            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {

                mousePos = Input.mousePosition;
                mousePos.z = 0f;

                objectPos = Camera.main.WorldToScreenPoint(transform.position);
                mousePos.x = mousePos.x - objectPos.x;
                mousePos.y = mousePos.y - objectPos.y;
                move.direction = Camera.main.transform.rotation * mousePos;
            }
            cooldown = fireRate;
        }
        cooldown--;
    }


}
