using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OnCollisionDeadPlatform : MonoBehaviour
{
    void Start()
    {
    }
    void OnCollisionEnter(Collision col){
      if (col.gameObject.tag == "HotCandle"){
        Destroy(col.gameObject);
    }
  }
}
