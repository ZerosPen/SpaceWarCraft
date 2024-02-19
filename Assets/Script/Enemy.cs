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
    private GameObject _redlaser;
    private float _firerate = 3.0f;
    private float _canFire = -1f;

    private NewBehaviourScript BluePlane;
    

    // Start is called before the first frame update
    void Start()
    {
        BluePlane = GetComponent<NewBehaviourScript>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMove();
        if (Time.time > _canFire)
        {
            _canFire = Time.time + _firerate;
            _firerate = Random.Range(3f, 7f);
            GameObject enemyLaser = Instantiate(_redlaser, transform.position, Quaternion.identity);
            Redlaser[] lasers = enemyLaser.GetComponentsInChildren<Redlaser>();
            
            for (int i = 0; i < lasers.Length; i++)
            {
                lasers[i].AssignEnemyLaser();
            }
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
                player.Damage(10);
                Debug.Log("Your Crash By enemy_1!");
                Destroy(this.gameObject);
            }
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
    }

    public void HitBlueLaser(int damaged)
    {
        _HealtPoint -= damaged;
        if (_HealtPoint < 1)
        {
            if (BluePlane != null)
            {
                BluePlane.AddScorePlayer(10);
            }
            Destroy(this.gameObject);
        }
    }

    public void HitGreenLaser(int damaged)
    {
        _HealtPoint-= damaged;
        if (_HealtPoint < 1)
        {
            Destroy(this.gameObject);
        }
    }

    public void HitRedLaser(int damage)
    {
        _HealtPoint -= damage;
        if (_HealtPoint < 1)
        {
            if (BluePlane != null)
            {
                BluePlane.AddScorePlayer(10);
            }
            Destroy(this.gameObject);
        }
    }
}