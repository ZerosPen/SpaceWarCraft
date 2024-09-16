using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[CreateAssetMenu]
public class PlaneDatabase : ScriptableObject
{
    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
    public Plane[] planes;
    public int PlaneCount 
    { 
        get
        {
            return planes.Length;
        }
    }

    public Plane GetPlane(int index)
    {
        return planes[index];
    }
}
