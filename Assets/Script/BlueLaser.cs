using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLaser : MonoBehaviour
{
    [SerializeField]
    private float velocity = 5f;
    private bool EnemyLaser = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
                player.Damage();
            }
        }

        if (other.tag == "GrayPlane" && EnemyLaser == true)
        {
            GrayePlane player = other.GetComponent<GrayePlane>();
            if (player != null)
            {
                player.Damage();
            }
        }

        if (other.tag == "BluePlane" && EnemyLaser == true)
        {
            NewBehaviourScript player = other.GetComponent<NewBehaviourScript>();
            if (player != null)
            {
                player.Damage();
            }
        }
    }
}
