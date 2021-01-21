using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    public GameObject enemyPrefab;
    public List<Enemy> enemies;

    public bool EnemyAlive = false;

    [SerializeField]
    private float startTime = 3.0f,
        spawnRate = 2.0f;
        
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Debug.LogError("Duplicate EnemyManager, destroying...", gameObject);
            Destroy(gameObject);
        }
    }

    void Start() // Also spawns enemies!
    {
        InvokeRepeating("SpawnEnemy", startTime, spawnRate);
        SpawnEnemy();
    }
    void Update()
    {
        if(!EnemyAlive)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Vector3 offset = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-2.0f, 2.0f), 0.0f);
        GameObject enemyClone = Instantiate(enemyPrefab, transform.position + offset, transform.rotation);
        enemyClone.GetComponent<Enemy>().rotSpeed = Random.Range(0, 2) * 2 - 1; // Gets -1 or 1, not 0. Essentially direction.
        EnemyAlive = true;
    }

    
}
