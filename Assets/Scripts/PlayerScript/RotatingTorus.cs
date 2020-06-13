using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingTorus : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("RotatingTorusFunction",0.04f,0.04f);
    }
    public void RotatingTorusFunction(){
        transform.Rotate(0.0f, 1.0f, 0.0f, Space.World);
    }

}
