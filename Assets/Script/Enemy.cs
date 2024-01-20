using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _ramspeed = 5.0f;
    [SerializeField]
    private int _HealtPoint = 10;
    [SerializeField]
    private GameObject _laser;
    private float _firerate = 3.0f;
    private float _canFire = -1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CalculateMove();
        if (Time.time > _canFire)
        {
            _canFire = Time.time + _firerate;
            _firerate = Random.Range(3f, 7f);
            Instantiate(_laser, transform.position, Quaternion.identity);
            Debug.Break();
        }
    }

    void CalculateMove()
    {
        transform.Translate(Vector3.down * _ramspeed * Time.deltaTime);
        if (transform.position.y < -5f)
        {
            float randomX = Random.Range(-8, 8);
            transform.position = new Vector3(randomX, 7, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BluePlane")
        {
            NewBehaviourScript player = other.GetComponent<NewBehaviourScript>();
            if (player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }

        if (other.tag == "GrayPlane")
        {
            GrayePlane player = other.GetComponent<GrayePlane>();
            if (player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }

        if (other.tag == "BlackPlane")
        {
            BlackPlane player = other.GetComponent<BlackPlane>();  
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }

        if (other.tag == "RedLaser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        if (other.tag == "BlueLaser")
        {
            Destroy(other.gameObject);
            _HealtPoint = -2;
            if (_HealtPoint < 1)
            {
                Destroy(this.gameObject);
            }
        }

    }
}