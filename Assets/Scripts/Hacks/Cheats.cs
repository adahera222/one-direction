using UnityEngine;
using System.Collections;

public class Cheats : MonoBehaviour {

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.O))
        {
            while(!SpawnController.Instance.SpawnObstacle());
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            while(!SpawnController.Instance.Spawn());
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            SpawnController.Instance.killEnemy();
        }
    }
}
