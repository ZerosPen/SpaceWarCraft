using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenLaser : MonoBehaviour
{
    [SerializeField]
    private float velocity = 5.5f;
    private bool _EnemyLaser = false;

    private NewBehaviourScript BluePlane;


    // Start is called before the first frame update
    void Start()
    {
        BluePlane = GetComponent<NewBehaviourScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_EnemyLaser == false)
        {
            MoveUp();
        }
        else
        {
            MoveDown();
        }


    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * velocity * Time.deltaTime);

        if (transform.position.y > 8f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

    void MoveDown()
    {
        transform.Translate(Vector3.down * velocity * Time.deltaTime);
        if (transform.position.y < -8f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

    public void AssignEnemyLaser()
    {
        _EnemyLaser = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BluePlane" && _EnemyLaser == true)
        {
            NewBehaviourScript player = other.GetComponent<NewBehaviourScript>();
            if (player != null)
            {
                player.DamageLaser(1);
            }
            Destroy(this.gameObject);
        }

        if (other.tag == "BlackPlane" && _EnemyLaser == true)
        {
            BlackPlane player = other.GetComponent<BlackPlane>();
            if (player != null)
            {
                player.LaserDamage(1);
            }
            Destroy(this.gameObject);
        }

        if (other.tag == "GrayPlane" && _EnemyLaser == true)
        {
            GrayePlane player = other.GetComponent<GrayePlane>();
            if (player != null)
            {
                player.Damagelaser(1);
            }
            Destroy(this.gameObject);
        }

        if (other.tag == "Enemy_1" && _EnemyLaser == false)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.HitGreenLaser(1);

            }
            Destroy(this.gameObject);
        }

        if (other.tag == "Falcon" && _EnemyLaser == false)
        {
            Falcon falcon = other.GetComponent<Falcon>();
            if (falcon != null)
            {
                falcon.HitGreenLaser(1);
            }
            Destroy(this.gameObject);
        }

        if (other.tag == "Mashle" && _EnemyLaser!= false)
        {
            EnemyMashle Mashle = other.GetComponent<EnemyMashle>();
            if (Mashle != null)
            {
                Mashle.HitGreenLaser(1);
                Destroy(this.gameObject);
            }
        }

        if (other.tag == "Bosslvl" && _EnemyLaser == false)
        {
            EnemyBoss Bosslvl = other.GetComponent<EnemyBoss>();
            if (Bosslvl != null)
            {
                Bosslvl.DamageLaser(1);
                Destroy(this.gameObject);
            }
        }
    }
}
