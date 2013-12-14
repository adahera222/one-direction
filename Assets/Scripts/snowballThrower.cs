using UnityEngine;
using System.Collections;

public class snowballThrower : MonoBehaviour {

    private Vector3 mousePos;
    private Vector3 objectPos;

    void FixedUpdate()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 0f;

        objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }
}
