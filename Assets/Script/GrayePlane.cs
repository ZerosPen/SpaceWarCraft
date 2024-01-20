using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrayePlane : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    private float _firerate = 0.5f;
    private float _cooldown = -1f;
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
        Movemnet();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _cooldown)
        {
            _cooldown= Time.time + _firerate;
            Instantiate(_laserPrefab, transform.position + new Vector3(0f , 1.6f, 0), Quaternion.identity);
        }

        // if E get press Laser beam
        // if Q get press KamuiHeal

    }

    void Movemnet()
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

        else if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }

        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
<<<<<<< HEAD
    }

    public void Damage()
    {
        _lives--;

        if (_lives < 1)
        {
            Destroy(this.gameObject);
        }
=======
>>>>>>> 67fa9c773894ef072990fd6d6d8896e8e7646bf9
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
