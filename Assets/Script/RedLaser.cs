using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redlaser : MonoBehaviour
{
    [SerializeField]
    private float velocity = 4f; 
    private bool _isEnemyLaser = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isEnemyLaser == false)
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
        _isEnemyLaser = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BlackPlane" && _isEnemyLaser == true)
        {
           BlackPlane player = other.GetComponent<BlackPlane>();
            if (player != null)
            {
                player.Damage();
            }
        }

        if (other.tag == "GrayPlane" && _isEnemyLaser == true)
        {
            GrayePlane player = other.GetComponent<GrayePlane>();
            if (player != null )
            {
                player.Damage();
            }
        }

        if (other.tag == "BluePlane" && _isEnemyLaser == true)
        {
            NewBehaviourScript player = other.GetComponent<NewBehaviourScript>();
            if (player != null )
            {
                player.Damage();
            }
        }
    }
}
