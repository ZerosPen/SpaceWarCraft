using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheild : MonoBehaviour
{
    [SerializeField]
    private int _HSP = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SheildReduce()
    {
        _HSP--;
        if (_HSP > 1)
        {
            Destroy(this.gameObject);
        }
    }
}
