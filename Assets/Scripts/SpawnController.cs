using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

    public int maxEnemies = 4;
    public int spawnTime = 3;
    public float radius = 2f;
    public float obstacleRadius = 2f;
    public int wave = 1;
    public int waveSize = 5;
    public int spawnrate = 100;
    public int numberOfWaves = 3;

    public static SpawnController Instance;

    public GameObject[] enemies;
    public GameObject obstacle;

    private int coolDown = 0;
    private int enemyCount = 0;
    private int obstacles = 0;
    private int enemiesKilledThisWave = 0;


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
        Debug.Log("EnemyCount--");
        enemyCount--;
        enemiesKilledThisWave++;
        if (enemiesKilledThisWave > waveSize)
        {
            wave++;
            waveSize += 3;
            maxEnemies++;
            if (wave > numberOfWaves)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (SpawnObstacle()) break;
                } 
                wave = 0;
                enemiesKilledThisWave = 0;
            }
            
        }
    }

    public bool Spawn()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        Vector3 position = Random.insideUnitSphere;
        position = position *  radius;
        position.z = 0;

        if (p == null) { this.enabled = false; return true; }

        if (Vector3.Distance(position, p.transform.position) > .5 && enemyCount < maxEnemies)
        {
            enemyCount++;
            int i = Random.Range(0, enemies.Length);

            GameObject e = Instantiate(enemies[i], position, transform.rotation) as GameObject;
            e.tag = "Enemy";
            Debug.Log("Enemy spawned at"+position.x +" " +position.y);
            return true;
        }
        else
        {
            Debug.Log("couldn't spawn, too close to player");
            return false;
        }


    }

    public bool SpawnObstacle()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        Vector3 position = Random.insideUnitSphere;
        position = position * obstacleRadius;
        position.z = 0;
        var rotation = Random.rotation;
        rotation.x = 0; rotation.y = 0;

        if (p == null) { this.enabled = false; return true; }

        if (Vector3.Distance(position, p.transform.position) >1 && obstacles<8)
        {
            var os = GameObject.FindGameObjectsWithTag("Hole");
            if (os != null)
            {
                foreach (var o in os)
                {
                    if (Vector3.Distance(position, o.transform.position) < 1)
                    {
                        Debug.Log("obstacles too close to spawn");
                        return false;
                    }
                }
            }
            Debug.Log("Obstacle Spawned at "+position.x +" " +position.y);
            GameObject obs = Instantiate(obstacle, position, rotation) as GameObject;
            obs.tag = "Hole";
            obstacles++;
            return true;
        }
        else
        {
            Debug.Log("couldn't spawn obstacle, too close to player");
            return false;
        }


    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, obstacleRadius);

    }

	// Update is called once per frame
	void Update () {

        if (coolDown > 0)
        {
            coolDown--;
        }
        else
        {
            for (int i = 0; i < 20; i++)
            {
                if (Spawn()) { coolDown = spawnrate * spawnTime; break; }                
            }
        }
        
	
	}
}
