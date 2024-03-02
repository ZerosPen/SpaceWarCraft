using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falcon : MonoBehaviour
{
    [SerializeField]
    private float _ramspeed = 5.0f;

    [SerializeField]
    private int _HealtPoint = 10;

    [SerializeField]
    private GameObject _bluelaser;
    private float _firerate = 3.0f;
    private float _canFire = -1f;
    private int _scorepoint = 10;

    private NewBehaviourScript BluePlane;
    private BlackPlane BlackPlane;
    private GrayePlane GrayPlane;

    // Start is called before the first frame update
    void Start()
    {
        GameObject bluePlaneObject = GameObject.Find("BluePlane");
        if (bluePlaneObject != null)
        {
            BluePlane = bluePlaneObject.GetComponent<NewBehaviourScript>();
        }
        GameObject blackPlaneObject = GameObject.Find("BlackPlane");
        if (blackPlaneObject != null)
        {
            BlackPlane = blackPlaneObject.GetComponent<BlackPlane>();
        }
        GameObject grayPlaneObject = GameObject.Find("GrayPlane");
        if (grayPlaneObject != null)
        {
            GrayPlane = grayPlaneObject.GetComponent<GrayePlane>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMove();
        if (Time.time > _canFire)
        {
            _canFire = Time.time + _firerate;
            _firerate = Random.Range(3f, 7f);
            GameObject enemyBlueLaser = Instantiate(_bluelaser, transform.position, Quaternion.identity);
            BlueLaser[] lasers = enemyBlueLaser.GetComponentsInChildren<BlueLaser>();
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
                player.Damage(15);
                Debug.Log("Your Crash By Falcon!");
            }
            Destroy(this.gameObject);
        }

        if (other.tag == "GrayPlane")
        {
            GrayePlane player = other.GetComponent<GrayePlane>();
            if (player != null)
            {
                player.CrashDamage(15);
            }
            Destroy(this.gameObject);
        }

        if (other.tag == "BlackPlane")
        {
            BlackPlane player = other.GetComponent<BlackPlane>();
            {
                player.CrashDamage(10);
            }
            Destroy(this.gameObject);
        }

        if (other.tag == "RedLaser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
    public void HitBlueLaser(int damaged)
    {
        _HealtPoint -= damaged;
        if (_HealtPoint < 1)
        {
            Destroy(this.gameObject);
        }
    }

    public void HitGreenLaser(int damaged)
    {
        _HealtPoint -= damaged;
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
            Destroy(this.gameObject);
        }
    }
    public void OnDestroy()
    {
        if (BluePlane != null)
        {
            BluePlane.AddScorePlayer(_scorepoint);
        }
        if (BlackPlane != null)
        {
            BlackPlane.AddScorePlayer(_scorepoint);
        }
        if (GrayPlane != null)
        {
            GrayPlane.AddScorePlayer(_scorepoint);
        }
    }
}