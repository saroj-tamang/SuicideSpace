using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFall : MonoBehaviour
{
    Vector2 startingPos;
    public GameObject ShakeGround;
    void Awake () {
        startingPos.x = transform.position.x;
        startingPos.y = transform.position.y;
    }
    void Start()
    {

    }

    void Update()
    {
   
    }
}
