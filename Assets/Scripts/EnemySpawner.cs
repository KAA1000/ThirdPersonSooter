using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyAI enemyPrefab;
    public EnemyHealth enemyHealth;

    public List<Transform> spawnPoints;
    public List<Transform> patrolPoints;
    

    private List<EnemyAI> enemies;
    private float lastEnemyCreateTime = 0;
     
    [SerializeField] private float enemySpawnCooldown =5;



    void Start()
    {
        enemies = new List<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemyUpdate();
        ClearEnemyList();
    }

    private void SpawnEnemyUpdate()
    {
        if (lastEnemyCreateTime + enemySpawnCooldown < Time.timeSinceLevelLoad )
        {
            var enemy = Instantiate(enemyPrefab);
            enemy.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
            enemy.patrolPoints = patrolPoints;
            enemies.Add(enemy);
            enemyHealth.enemyHp += 2;
            lastEnemyCreateTime = Time.timeSinceLevelLoad;
            enemySpawnCooldown -= 0.1f;
            enemySpawnCooldown = Mathf.Clamp(enemySpawnCooldown,1,10);
        }
    }

    private void ClearEnemyList()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].IsEnemyAlive()) continue;
            enemies.RemoveAt(i);
            
        }

    }
}
