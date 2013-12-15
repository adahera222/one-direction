using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour {

    public static Wind Instance;
    public float windForce = 0.01f;
    public GameObject wind;
    public float startDistance = 6f;

    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of Wind!");
        }
        Instance = this;
    }
    public Vector2 direction = new Vector2(-1, 0);
    public int probability = 75;
    private Vector2 movement;
    private int seed = 0;
    private int cooldown = 0;
    private float displayStart = 100;
    private bool canBlow = false;
    private int rate = 100;

    void Update()
    {
        if (cooldown < 0)
        {
            seed = Random.Range(0, probability);
            if (seed == 1)
            {

                GameObject w = Instantiate(wind, -direction.normalized * startDistance, Quaternion.identity) as GameObject;
                MoveScript move = w.GetComponent<MoveScript>();
                move.direction = direction;
                move.speed = Vector2.one*20;
                Destroy(w, 3);

                displayStart = 50;
                canBlow = true;
            }
            cooldown = 100;
        }
        cooldown--;
        if (canBlow) { addWind(); }
    }

    void addWind()
    {
        if (displayStart <0)
        {
            movement = windForce * direction.normalized;
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            var player = GameObject.FindGameObjectWithTag("Player");
            if (enemies == null || player == null) return;

            foreach (var e in enemies)
            {
                e.rigidbody2D.AddForce(movement);
            }

            player.rigidbody2D.AddForce(movement);
            canBlow = false;
        }
        else
        {
            displayStart--;
        }
        
    }

}
