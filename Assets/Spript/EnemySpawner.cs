using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyHealth _enemyHealth;
    public EnemyAI enemyPrefab;
    public PlayerController player;

    public int enimesMaxCount = 5;
    public float delay = 3;
    public float increaseEnemiesCountDelay = 30;

    public List<Transform> _spawnerPoint;
    public List<Transform> patrolPoints;
    public List<EnemyAI> _enemies;

    private float _timeLastSpawned;

    private void Start()
    {
        _spawnerPoint = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        _enemies = new List<EnemyAI>();

        Invoke("IncreaseEnemies", increaseEnemiesCountDelay);
    }

    private void IncreaseEnemies()
    {
        enimesMaxCount++;
        Invoke("IncreaseEnemies", increaseEnemiesCountDelay);
    }
    
    private bool IsAlive()
    {
        return _enemyHealth.value > 0;
    }

    private void Update()
    {
        CheekForDeadEnenmies();

        CreateEnemy();
    }

    private void CheekForDeadEnenmies()
    {
        for(var i = 0; i < _enemies.Count; i ++)
        {
            if (_enemies[i].IsAlive())
            {
                continue;
            }
            _enemies.RemoveAt(i);
            i--;
        }
    }

    private void CreateEnemy()
    {
        if (_enemies.Count >= enimesMaxCount)
        {
            return;
        }

        if (Time.time - _timeLastSpawned < delay)
        {
            return;
        }

        var enemy = Instantiate(enemyPrefab);
        enemy.transform.position = _spawnerPoint[Random.Range(0, _spawnerPoint.Count)].position;
        enemy.player = player;
        enemy.patrolPoints = patrolPoints;
        _enemies.Add(enemy);
        _timeLastSpawned = Time.time;
    }
}
