using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCoin : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        transform.Rotate(0, Time.deltaTime*30f, 0, Space.World);
    }
}
