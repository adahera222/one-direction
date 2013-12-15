using UnityEngine;
using System.Collections;

public class PositionUI : MonoBehaviour {

    public int fromRight = 100;
    public int fromBottom = 100;

	// Use this for initialization
	void Start () {

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-fromRight,fromBottom,10));
	}
}
