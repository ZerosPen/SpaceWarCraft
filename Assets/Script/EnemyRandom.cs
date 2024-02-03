using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandom : MonoBehaviour
{
    [SerializeField]
    private int enemyID;
    private SpawnManager _spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void CheckEnemy()
    {
        if (_spawnManager != null)
        {
            switch(enemyID)
            {
                case 0:
                    _spawnManager.Enemy;
            }
        }
    }*/
 }
