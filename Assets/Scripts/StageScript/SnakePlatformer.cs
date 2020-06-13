using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SnakePlatformer : MonoBehaviour
{
    private float speed = 1f;
    private bool dirRight = true;
    private GameObject Player;
    void Start()
    {
        Player= GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (dirRight){
           gameObject.transform.Translate (Vector3.right * speed * Time.deltaTime);
        }
        else if(!dirRight)
        {
           gameObject.transform.Translate (-Vector3.right * speed * Time.deltaTime); 
        }

        if(transform.position.x >= 1.31) {
            dirRight = false;
        }         
        if(transform.position.x <= -3.91) {
            dirRight = true;
        }  
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
