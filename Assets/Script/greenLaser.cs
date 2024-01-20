using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenLaser : MonoBehaviour
{
    [SerializeField]
    private float velocity = 5.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * velocity * Time.deltaTime);

        if (transform.position.y > 8f)
        {
            Destroy(this.gameObject);
        }

    }
}
