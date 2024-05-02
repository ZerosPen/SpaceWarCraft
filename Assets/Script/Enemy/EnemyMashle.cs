using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMashle : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;

    private int _HP = 3;

    [SerializeField]
    private GameObject _greenlaser;
    [SerializeField]
    private float _firerate = 3.0f;
    [SerializeField]
    private float _canFire = 1f;
    private int _scorepoint = 15;

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
        calculateMove();
        /*if (Time.time > _canFire)
        {
            _canFire = Time.time + _firerate;
            _firerate = Random.Range(3f, 7f);
            GameObject enemyGreenLaser = Instantiate(_greenlaser, transform.postion);
        }*/
    }

    void calculateMove()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -8f)
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
                player.Damage(2);
                Debug.Log("Your Crash By enemy_1!");
            }
            Destroy(this.gameObject);
        }

        if (other.tag == "GrayPlane")
        {
            GrayePlane player = other.GetComponent<GrayePlane>();
            if (player != null)
            {
                player.CrashDamage(2);
            }
            Destroy(this.gameObject);
        }

        if (other.tag == "BlackPlane")
        {
            BlackPlane player = other.GetComponent<BlackPlane>();
            {
                player.CrashDamage(2);
            }
            Destroy(this.gameObject);
        }
    }

    public void HitBlueLaser(int damage)
    {
        _HP -= damage;
        if (_HP < 1)
        { 
            Destroy(this.gameObject);
            if (BluePlane != null)
            {
                BluePlane.AddScorePlayer(10);
            }
        }
    }

    public void HitGreenLaser(int damaged)
    {
        _HP -= damaged;
        if (_HP < 1)
        {
            Destroy(this.gameObject);
            if (BluePlane != null)
            {
                BluePlane.AddScorePlayer(10);
            }
        }
    }

    public void HitRedLaser(int damage)
    {
        _HP -= damage;
        if ( _HP < 1)
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
    }
}
