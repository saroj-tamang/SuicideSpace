using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpinCube : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("SpinCubes",0.01f,0.01f);
    }
    public void SpinCubes(){
        gameObject.transform.Rotate(0f, 0.1f, 0f, Space.Self);
    }
}
