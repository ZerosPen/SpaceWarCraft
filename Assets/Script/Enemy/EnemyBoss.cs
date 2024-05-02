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
    [SerializeField]
    private GameObject BossPlane;

    [SerializeField]
    private GameObject[] ModeAttack;

    private float fireRate = 3.0f;
    private float canFire = -1f;

    private SpawnManager SPmanager;
    private NewBehaviourScript BluePlane;
    private BlackPlane blackPlane;
    private GrayePlane GrayPlane;
    private BlueLaser Blaser;
    private greenLaser Glaser;
    private Redlaser Rlaser;
    private GameManager GManager;
   
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
        SPmanager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if (SPmanager == null)
        {
            Debug.LogError("The Spawn Manager is NULL");
        }
        GManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (GManager == null)
        {
            Debug.LogError("The Game Manager is NULL");
        }
        GameObject bLaserObject = GameObject.Find("BlueLaser");
        if (bLaserObject != null)
        {
            Blaser = bLaserObject.GetComponent<BlueLaser>();
        }
        GameObject GLaserObject = GameObject.Find("GreenLaser");
        if (GLaserObject != null)
        {
            Glaser = GLaserObject.GetComponent<greenLaser>();
        }
        GameObject RLaserObject = GameObject.Find("laser");
        if (RLaserObject != null)
        {
            Rlaser = RLaserObject.GetComponent<Redlaser>();
        }
    }

    public void bossStartLvl()
    {
        BossStart = true;
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
            SPmanager.SpawnConttrol(false);
            StraveBoss = true;
            currentTarget = pointA.position;
        }
    }

    void modeAttack()
    {
        if (StraveBoss == true)
        {
            if (Time.deltaTime > canFire)
            {
                canFire = Time.deltaTime + fireRate;
                fireRate = Random.Range(3f, 7f);
                int randomModeAttack = Random.Range(0, 2);
                GameObject Attack = Instantiate(ModeAttack[randomModeAttack], transform.position, Quaternion.identity);
                BlueLaser[] attacks = Attack.GetComponentsInChildren<BlueLaser>();

                for (int i = 0; i < attacks.Length; i++)
                {
                    attacks[i].AssignEnemyLaser();
                }
            }
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

    public void HitBlueLaser(int DMG)
    {
        HitPoints -= DMG;
        if (HitPoints < 0)
        {
            Destroy(this.gameObject);
            Defeat();
        }
    }
    public void HitRLaser(int DMG)
    {
        HitPoints -= DMG;
        if (HitPoints < 0)
        {
            Destroy(this.gameObject);   
        }
    }
    public void HitGLaser(int DMG)
    {
        HitPoints -= DMG;
        if (HitPoints < 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Defeat()
    {
        GManager.winLvl();
        Debug.Log("the Game id END!");
    }
}
