using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _container;
    [SerializeField]
    private GameObject[] enemys;
    [SerializeField]
    private GameObject[] powerUps;
    [SerializeField]
    private bool _isSpawning = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPower());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(3.5f);

        while (_isSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8, 8), 7, 0);
            int randomEnemySpawn = Random.Range(0, 2);
            GameObject NewEnemy = Instantiate(enemys[randomEnemySpawn], posToSpawn, Quaternion.identity);
            NewEnemy.transform.parent = _container.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpawnPower()
    {
        yield return new WaitForSeconds(3.5f);

        while (_isSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8, 8), 7, 0);
            int randomPoweUpSpawn = Random.Range(0, 1);
            GameObject PowerUP = Instantiate(powerUps[randomPoweUpSpawn], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

    public void OnPlayerDeath()
    {
        _isSpawning = true;
    }

}
