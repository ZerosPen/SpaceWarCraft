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
    private GameObject EnemyBoss;
    [SerializeField]
    private bool _isSpawning = false;
    [SerializeField]
    private bool EndLvl = false;
    private bool SpawnRate = false;
    private EnemyBoss bossLvl;


    // Start is called before the first frame update
    void Start()
    {
        bossLvl = GameObject.Find("EnemyBoss").GetComponent<EnemyBoss>();
        if (bossLvl == null)
        {
            Debug.LogError("GameObject are GONE!");
        }
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPower());
    }

    // Update is called once per frame
    void Update()
    {
        if (EndLvl == true)
        {
            bossLvl.bossStartLvl();
        }
    }

    public void SpawnConttrol(bool change)
    {
        EndLvl = change;
        SpawnRate = true;
    }

    IEnumerator SpawnEnemy()
    {
        if (SpawnRate == false)
        {
            yield return new WaitForSeconds(3.5f);
        }
        else
        {
            float timer = Random.Range(3.5f, 5.5f);
            yield return new WaitForSeconds(timer);
        }


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
        if (SpawnRate == true)
        {
            float randomtimer = 10f;
            yield return new WaitForSeconds(randomtimer);
        }
        else
        {
            float randomtimer = Random.Range(3.5f, 5.5f);
            yield return new WaitForSeconds(randomtimer);
        }

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

