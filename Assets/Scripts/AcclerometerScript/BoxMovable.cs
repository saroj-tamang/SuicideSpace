using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoxMovable : MonoBehaviour
{
    private GameObject Player;
    public float rightmaxvalue;
    public float leftminvalue;
    void Start()
    {
         Player= GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        transform.Translate(Input.acceleration.x*0.5f ,0f, 0f);
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, leftminvalue, rightmaxvalue);
        transform.position = clampedPosition;
       
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
