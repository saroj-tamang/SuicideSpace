using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SmoothJump : MonoBehaviour
{
    public  float fallMultiplier=1.5f;
    public float lowJumpMultiplier=0.5f;
    Rigidbody rb;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(rb.velocity.y<0){
            rb.velocity+=Vector3.up*Physics.gravity.y*(fallMultiplier-1)*Time.deltaTime;
        }
        else if(rb.velocity.y>0){
            rb.velocity+=Vector3.up*Physics.gravity.y*(lowJumpMultiplier-1)*Time.deltaTime;
        }
    }
}
