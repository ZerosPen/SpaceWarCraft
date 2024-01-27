using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLaser : MonoBehaviour
{
    [SerializeField]
    private float velocity = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveUp();

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
}
