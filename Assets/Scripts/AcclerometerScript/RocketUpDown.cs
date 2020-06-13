using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RocketUpDown : MonoBehaviour
{
    public float highvalue;
    public float lowvalue;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(0f ,Input.acceleration.y*0.5f, 0f);
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, lowvalue, highvalue);
        transform.position = clampedPosition;
        
    }
}
