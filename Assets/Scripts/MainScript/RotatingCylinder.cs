using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotatingCylinder : MonoBehaviour
{
    public float x_value,y_value,z_value;
    void Start()
    {
        InvokeRepeating("RotateCylinder",0.01f,0.03f);
    }
    
    void RotateCylinder(){
        transform.Rotate(1.0f, 0.0f, 0.0f, Space.World);
    }
}
