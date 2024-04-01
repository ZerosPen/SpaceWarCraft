using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PowerUP : MonoBehaviour
{
    private NewBehaviourScript BluePlane;
    private BlackPlane blackPlane;
    private GrayePlane GrayPlane;

    [SerializeField]
    private float _speed = 3.0f;

    [SerializeField]
    private int powerupID;
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
        
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -4.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BluePlane")
        {
            NewBehaviourScript player = other.transform.GetComponent<NewBehaviourScript>();
            if (player != null)
            {
                switch(powerupID) 
                {
                    case 0:
                        player.healHitpoints();
                        break;
                    case 1:
                        player.speedboost();
                        break;
                    default:
                        Debug.Log("Default Value");
                        break;
                }
                Destroy(this.gameObject);
            }
        }
    }
}
