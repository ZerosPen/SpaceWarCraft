using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLaser : MonoBehaviour
{
    [SerializeField]
    private float velocity = 5f;
    private bool EnemyLaser = false;
    private bool BossMode = false;

    private NewBehaviourScript BluePlane;
    private BlackPlane blackPlane;
    private GrayePlane GrayPlane;
    private EnemyBoss BossPlane;


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
            blackPlane = blackPlaneObject.GetComponent<BlackPlane>();
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
        if (EnemyLaser == false)
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
        EnemyLaser = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BlackPlane" && EnemyLaser == true)
        {
            BlackPlane player = other.GetComponent<BlackPlane>();
            if (player != null)
            {
                player.LaserDamage(5);
            }
            Destroy(this.gameObject);
        }

        if (other.tag == "GrayPlane" && EnemyLaser == true)
        {
            GrayePlane player = other.GetComponent<GrayePlane>();
            if (player != null)
            {
                player.Damagelaser(5);
            }
            Destroy(this.gameObject);
        }

        if (other.tag == "BluePlane" && EnemyLaser == true)
        {
            NewBehaviourScript player = other.GetComponent<NewBehaviourScript>();
            if (player != null)
            {
                player.DamageLaser(5);
            }
            Destroy(this.gameObject);
        }

        if (other.tag == "Enemy_1" && EnemyLaser == false)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy !=null)
            {
                enemy.HitBlueLaser(10);
            }
            Destroy(this.gameObject);
            
        }

        if (other.tag == "Falcon" && EnemyLaser == false)
        {
            Falcon falcon = other.GetComponent<Falcon>();
            if (falcon != null)
            {
                falcon.HitBlueLaser(10);
            }
            Destroy(this.gameObject);
            
        }

        if (other.tag == "Mashle" && EnemyLaser == false)
        {
            EnemyMashle Mashle = other.GetComponent<EnemyMashle>();
            if (Mashle != null)
            {
                Mashle.HitBlueLaser(10);
            }
            Destroy(this.gameObject);  
        }
    }
}
