using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBoss : MonoBehaviour
{
    [SerializeField]
    private int HitPoints = 10;
    [SerializeField]
    private float Movement = 5.0f;
    [SerializeField]
    private float StraveSpeed = 0.5f;
    private NavMeshAgent BossPlane;

    [SerializeField]
    private List<GameObject> ModeAttack;

    private float fireRate = 3.0f;
    private float canFire = -1f;

    private NewBehaviourScript BluePlane;
    private BlackPlane blackPlane;
    private GrayePlane GrayPlane;
    private BlueLaser Blaser;
    private greenLaser Glaser;
    private Redlaser Rlaser;
   
    [SerializeField]
    private bool BossStart = false;
    [SerializeField]
    private bool StraveBoss = false;

    [SerializeField]
    private Transform pointA, pointB, pointC;
    private Vector3 currentTarget;
    


    // Start is called before the first frame update
    void Start()
    {
        GameObject bluePlaneObject = GameObject.Find("BluePlane");
        if (bluePlaneObject != null ) 
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
        GameObject bLaserObject = GameObject.Find("BlueLaser");
        if (bLaserObject != null)
        {
            Blaser = bluePlaneObject.GetComponent<BlueLaser>();
        }
        GameObject GLaserObject = GameObject.Find("GreenLaser");
        if (GLaserObject != null)
        {
            Glaser = bluePlaneObject.GetComponent<greenLaser>();
        }
        GameObject RLaserObject = GameObject.Find("laser");
        if (RLaserObject != null)
        {
            Rlaser = bluePlaneObject.GetComponent<Redlaser>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (BossStart == true)
        {
            MovementDown();
        }
        else
        {
            strave();
        }
    }

    void MovementDown()
    {
        transform.Translate(Vector3.down * Movement * Time.deltaTime);
        if (transform.position.y <= 5f)
        {
            BossStart = false;
            StraveBoss = true;
            currentTarget = pointA.position;
        }
    }

    void strave()
    {
        if (StraveBoss == true)
        {
           if (transform.position == pointA.position)
            {
                currentTarget = pointB.position;
            }

            if (transform.position == pointB.position)
            {
                currentTarget = pointC.position;
            }

           if (transform.position == pointC.position)
            {
                currentTarget = pointB.position;
            }
           transform.position = Vector3.MoveTowards(transform.position, currentTarget, StraveSpeed * Time.deltaTime);
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
            }
            Destroy(this.gameObject);
        }

        if (other.tag == "GrayPlane")
        {
            GrayePlane player = other.GetComponent<GrayePlane>();
            if (player != null)
            {
                player.CrashDamage(10);
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
    }
    public void HitBlueLaser(int damage)
    {
        HitPoints -= damage;
        if (HitPoints < 1)
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
        HitPoints -= damaged;
        if (HitPoints < 1)
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
        HitPoints -= damage;
        if (HitPoints < 1)
        {
            Destroy(this.gameObject);
        }
    }
/*    public void OnDestroy()
    {
        if (BluePlane != null)
        {
            end
        }
    }*/
}
