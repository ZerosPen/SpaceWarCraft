using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _container;
    [SerializeField]
    private bool _isSpawning = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while (_isSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8, 8), 7, 0);
            GameObject NewEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            NewEnemy.transform.parent = _container.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    public void OnPlayerDeath()
    {
        _isSpawning = true;
    }

}
