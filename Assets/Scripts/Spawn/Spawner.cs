using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _countEnemy;

    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _distanceSpawn;

    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField] private EntityFabric _entityFabric;

    private List<Enemy> _enemies;

    private void Start()
    {
        
        SpawnEnemise();
    }
    private void SpawnEnemise()
    {
        _enemies = new List<Enemy>();

        var currentPosition = _spawnPoint;


        for (int i = 0; i <= _countEnemy - 1; i++)
        {
            currentPosition.position = CreateNewPosition(currentPosition.position , i);
            _enemies.Add(CreatEnemy(currentPosition));
            currentPosition = _enemies[i].transform; 
        }

    }
    private Enemy CreatEnemy(Transform currentPosition)
    {
        var enemy = _entityFabric.GetEnemy(_enemyTemplate);
        return Instantiate(enemy, currentPosition.position, Quaternion.identity, transform);
    }
    private Vector3 CreateNewPosition(Vector3 currentPosition, int i)
    {
        Vector3 newPosition; 

        if (i % 2 == 0)
            return new Vector3(currentPosition.x + _distanceSpawn  , currentPosition.y , currentPosition.z + 2);


        newPosition = new Vector3(currentPosition.x + _distanceSpawn + 1, currentPosition.y, currentPosition.z - 2);
        return newPosition;
    }

    


}
