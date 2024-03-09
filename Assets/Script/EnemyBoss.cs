using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    [SerializeField]
    private int HitPoints = 10;
    [SerializeField]
    private float Movement = 5.0f;
    [SerializeField]
    private float StraveSpeed = 0.5f;

    [SerializeField]
    private GameObject ModeAttack_1;
    [SerializeField]
    private GameObject ModeAttack_2;
    [SerializeField] 
    private GameObject ModeAttack_3;
    private float fireRate = 3.0f;
    private float canFire = -1f;

    private NewBehaviourScript BluePlane;
    private BlackPlane blackPlane;
    private GrayePlane GrayPlane;
    [SerializeField]
    private bool BossStart = false;
    private bool StraveBoss = false;
    private float WayPoint_A = -5;


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
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMove();
    }

    void CalculateMove()
    {
        if (BossStart == true)
        {
            transform.Translate(Vector3.down * Movement * Time.deltaTime);
            if (transform.position.y <= 4.9) 
            {
                BossStart = false;
                StraveBoss = true;
            }
        }
    }
}
