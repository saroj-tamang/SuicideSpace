using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RollingDanger : MonoBehaviour
{
    void Start()
    {       
    }
    void Update()
    {
         transform.Rotate(Time.deltaTime*-25f,0, 0, Space.World);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "DeadPlatformer"){
           Destroy(gameObject);
        }
    }
}
