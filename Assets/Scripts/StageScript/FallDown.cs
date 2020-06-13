using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
    }
    private void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.tag=="Player"){
           Invoke("FallDownPlatform",2f);
       }
       else if(other.gameObject.tag=="DeadPlatform"){
           Destroy(gameObject);
       }
    }
    public void FallDownPlatform(){
           GetComponent<Rigidbody>().useGravity = true;
    }
}
