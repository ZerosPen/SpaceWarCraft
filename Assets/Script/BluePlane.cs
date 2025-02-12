using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.5f;

    [SerializeField]
    private GameObject _blueLaserPrefab;
    [SerializeField]
    private GameObject _quadFiring;
    private float _firerate = 0.35f;
    private float _coolDown = 0.5f;

    [SerializeField]
    private SpriteRenderer _sheild;

    private bool _quadFiringAct = false;
    [SerializeField]
    private GameObject _shieldVisual;

    private SpawnManager _spawnManager;
    private float _SheildCoolDown = 3.5f;


    [SerializeField]
    private int _lives = 3;
   

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if(_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
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
    }

<<<<<<< HEAD
=======
    public void shieldIsActiv()
    {
        _sheildAct = true;
        StartCoroutine(SheildDownTime());
    }

    IEnumerator SheildDownTime()
    {
        yield return new WaitForSeconds(15.0f);
        _sheildAct = false;
    }

>>>>>>> 67fa9c773894ef072990fd6d6d8896e8e7646bf9
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


    public void Damage()
    {
        _lives--;

        if (_lives < 1)
        {
            Destroy(this.gameObject);
            _spawnManager.OnPlayerDeath();
        }
    }

}
