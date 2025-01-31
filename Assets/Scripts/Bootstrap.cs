using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PlayerSystem _playerSystem;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private InventoryManager _inventoryManager;
    void Start()
    {
        _playerSystem.Initialize();
        _inventoryManager.Initialize();
        _enemySpawner.Initialize();
        
    }
    void Update()
    {
        _playerSystem.UpdatePlayerSystem();
        _inventoryManager.UpdateInvetoryManager();

    }
}
