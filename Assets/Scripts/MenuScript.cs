using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

    void Update()
    {
        if(Input.anyKeyDown)
        {
            Application.LoadLevel("Level1");
        }

    }

}
