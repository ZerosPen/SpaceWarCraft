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

    private bool _quadFiringAct = false;
    private bool _sheildAct = false;


   /* [SerializeField]
    private GameObject _HexaSheild;
    [SerializeField]
    private float _coolDownSkill = -5f;
    private float _duration = 10f;*/

    [SerializeField]
    private int _lives = 3;
   

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _coolDown)
        {
            FireLaser();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            shieldIsActiv();
        }

        if (Input.GetKeyDown(KeyCode.E)) 
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
            Instantiate(_quadFiring, transform.position, Quaternion.identity);
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

    public void shieldIsActiv()
    {
        _sheildAct= true;
        StartCoroutine(SheildDownTime());
    }

    IEnumerator SheildDownTime()
    {
        yield return new WaitForSeconds(15.0f);
        _sheildAct= false;
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

    public void Damage()
    {
        _lives--;

        if (_lives < 1)
        {
            Destroy(this.gameObject);
        }
    }

}
