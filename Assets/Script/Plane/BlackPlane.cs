using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BlackPlane : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.5f;

    [SerializeField]
    private GameObject _laserPrefab;
    private float _firerate = 0.5f;
    private float _coolDown = -1.0f;

    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;
    private UIManager uiManager;

    [SerializeField]
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL");
        }
        if (uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _coolDown)
        {
            _coolDown = Time.time + _firerate;
            Instantiate(_laserPrefab, transform.position + new Vector3(0.256f, 1.05f, 0), Quaternion.identity);
            Instantiate(_laserPrefab, transform.position + new Vector3(-0.256f, 1.05f, 0), Quaternion.identity);
        }

        // press Q blackhole
        // press E mothership

    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }

        if (transform.position.y > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    public void LaserDamage(int hit)
    {
        _lives -= hit;
        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void CrashDamage(int crash)
    {
        _lives -= crash;

        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }


    public void AddScorePlayer(int points)
    {
        score += points;
        uiManager.UpdateScore(score);
    }

}