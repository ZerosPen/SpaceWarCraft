using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public PlaneDatabase planeDB;
    public SpriteRenderer planemodel;

    private int selectedOption = 0;

    [SerializeField]
    private float _speed = 4.5f;
    [SerializeField]
    private AudioClip _laserSound;
    private AudioSource _audioSource;

    [SerializeField]
    private GameObject _blueLaserPrefab;
    [SerializeField]
    private GameObject _quadFiring;
    [SerializeField]
    private float _firerate = 0.35f;
    [SerializeField]
    private float _coolDown = 0.05f;
    [SerializeField]
    private GameObject Boss;

    [SerializeField]
    private SpriteRenderer _sheild;

    private bool _quadFiringAct = false;
    [SerializeField]
    private GameObject _shieldVisual;

    private SpawnManager _spawnManager;
    private Enemy _enemy;
    private Falcon falcon;
    private EnemyMashle mashle;
    private EnemyBoss BossLvl;
    private UIManager uiManager;
    private GameManager GManager;
    private float _SheildCoolDown = 3.5f;
    private PowerUP Powerup;
    private bool Players = false;
    [SerializeField]
    private bool EndLvlCon = false;

    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private int maxlives = 200;
    [SerializeField]
    private bool _HEAL = false;
    private int heal = 1;
    [SerializeField]
    private bool speedboostact = false;
    private float speedbooster = 2;

    [SerializeField]
    private int score;


    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdatePlane(selectedOption);

        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL");
        }
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        if (uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL");
        }
        GManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("The AudioSource on the Player is NULL");
        }
        else
        {
            _audioSource.clip = _laserSound;
        }
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (_lives > 200)
        {
            int penaltyHP = _lives - maxlives;
            _lives = _lives - penaltyHP;
        }

        Movement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _coolDown)
        {
            FireLaser();
        }

        if (Input.GetKeyDown(KeyCode.E) && Time.time > _SheildCoolDown)
        {
            shieldIsActiv();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            QuadFiringAct();
        }
        EndLvl();

    }

    private void UpdatePlane(int selectedOption)
    {
        Plane plane = planeDB.GetPlane(selectedOption);
        planemodel.sprite = plane.PlaneModels;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectOption");
    }


    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }

        if (transform.position.y >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        _coolDown = Time.time + _firerate;
        if (_quadFiringAct == true)
        {
            Instantiate(_quadFiring, transform.position + new Vector3(1.15f, 0.7f, 0), Quaternion.identity);
            if (transform.position.y > 8f)
            {
                Destroy(_quadFiring);
            }
        }

        else
        {
            Instantiate(_blueLaserPrefab, transform.position + new Vector3(1.15f, 1.05f, 0), Quaternion.identity);
            Instantiate(_blueLaserPrefab, transform.position + new Vector3(-1.15f, 1.05f, 0), Quaternion.identity);
        }
        _audioSource.Play();
    }

    void QuadFiringAct()
    {
        _quadFiringAct = true;
        StartCoroutine(QuadFiringDownTime());
    }

    IEnumerator QuadFiringDownTime()
    {
        yield return new WaitForSeconds(5.0f);
        _quadFiringAct = false;
    }
    public void shieldIsActiv()
    {
        _shieldVisual.SetActive(true);
        StartCoroutine(SheildDownTime());
    }

    IEnumerator SheildDownTime()
    {
        yield return new WaitForSeconds(15.0f);
        _shieldVisual.SetActive(false);
    }

    public void healHitpoints()
    {
        _HEAL = true;
        _lives += heal;
        if (_lives == 2)
        {
            Debug.Log("Small repair to all Engine and wing right and left!!!");
        }
        if (_lives == 3)
        {
            Debug.Log("all Engine and wing right and left has been repair !!!");
        }
       /* if (_lives == 4)
        {
            Debug.Log("wing left get some armor");
        }
        if (_lives == 5)
        {
            Debug.Log("wing right get some armor");
        }
        else if (_lives == 6)
        {
            Debug.Log("all frame been upgrade");
        }*/
       uiManager.updatelive(_lives);
        StartCoroutine(HealsDownTime());
    }

    IEnumerator HealsDownTime()
    {
        yield return new WaitForSeconds(1.0f);
        _HEAL = false;
    }

    public void speedboost()
    {
        speedboostact = true;
        _speed *= speedbooster;
        StartCoroutine(speedBoostDown());
    }

    IEnumerator speedBoostDown()
    {
        yield return new WaitForSeconds(5.0f);
        speedboostact = false;
        _speed /= speedbooster;
    }

    public void Damage(int crash)
    {
        _lives -= crash;

        if (_lives == 2)
        {
            Debug.Log("Engine 1 and wing left is broken!!!");
        }
        else if (_lives == 1)
        {
            Debug.Log("lost all Engine and wing right and left is broken!!!");
        }
        uiManager.updatelive(_lives);

        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void DamageLaser(int hit)
    {
        _lives -= hit;

        if (_lives == 2)
        {
            Debug.Log("Engine 1 and wing left is broken!!!");
        }
        if (_lives == 1)
        {
            Debug.Log("lost all Engine and wing right and left is broken!!!");
        }

        if (_lives < 1)
        {
            Debug.Log("we lost a spacecraft!!!");
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
            GManager.GameOver();
        }

        uiManager.updatelive(_lives);
    }

    public void AddScorePlayer(int points)
    {
        score += points;
        uiManager.UpdateScore(score);
    }

    public void EndLvl()
    {
        if (score >= 150 && EndLvlCon == false)
        {
            _spawnManager.SpawnConttrol(true);
            EndLvlCon = true;
        }
        else
        {
            _spawnManager.SpawnConttrol(false);
        }
    }

    public void swicthcond()
    {
        EndLvlCon = true;
    }
}