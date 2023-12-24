using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _ramspeed = 5.0f;

    public 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _ramspeed * Time.deltaTime);
        if (transform.position.y < -5f)
        {
            float randomX = Random.Range(-8, 8);
            transform.position = new Vector3(randomX, 7, 0);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("We Been RAM BY ENEMY! The cordinet is " + other.transform.name);
    }
}
