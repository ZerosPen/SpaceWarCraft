using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemyShot : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
