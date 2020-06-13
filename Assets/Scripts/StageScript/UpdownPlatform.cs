using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UpdownPlatform : MonoBehaviour
{
    private GameObject Player;
    void Start()
    {
         Player= GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }
     void OnCollisionEnter(Collision collision){
          if (collision.gameObject.tag == "Player"){
              Player.transform.parent=transform;
          }
     }
     void OnCollisionExit(Collision collision){
          if (collision.gameObject.tag == "Player"){
              Player.transform.parent=null;
          }
     }
}
