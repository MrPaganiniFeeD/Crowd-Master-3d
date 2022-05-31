using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFabric : MonoBehaviour
{
    [SerializeField] private Player _player;


    public Enemy GetEnemy(Enemy enemy)
    {
        return enemy;
    }
}
