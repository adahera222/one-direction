using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

    public int maxEnemies = 4;
    public int spawnTime = 5;
    public float radius = 2f;

    public static SpawnController Instance;

    public GameObject[] enemies;

    private int coolDown = 0;
    private int enemyCount = 0;
    private int spawnrate = 100;

    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SpawnController!");
        }

        Instance = this;
    }

    void Start()
    {
        coolDown = 100;
    }

    public void killEnemy()
    {
        enemyCount--;
    }

    bool Spawn()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        Vector3 position = Random.insideUnitSphere;
        position = position *  radius;
        position.z = 0;

        if (p == null) { this.enabled = false; }

        if (Vector3.Distance(position, p.transform.position) > .5)
        {
            enemyCount++;
            int i = Random.Range(0, enemies.Length);

            GameObject e = Instantiate(enemies[i], position, transform.rotation) as GameObject;
            e.tag = "Enemy";
            return true;
        }
        else
        {
            Debug.Log("couldn't spawn, too close to player");
            return false;
        }


    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);

    }

	// Update is called once per frame
	void Update () {

        if (coolDown > 0)
        {
            coolDown--;
        }
        else
        {
            coolDown = spawnrate * spawnTime;
            while (!Spawn()) ;
        }
        
	
	}
}
