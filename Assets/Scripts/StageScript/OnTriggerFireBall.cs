using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OnTriggerFireBall : MonoBehaviour
{
    public GameObject FireBall,FireBall1,FireBall2,FireBall3,FireBall4,FireBall5;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
     private void OnTriggerEnter(Collider other){
          if(other.tag == "Player"){
              FireBall.GetComponent<Rigidbody>().useGravity=true;
               FireBall1.GetComponent<Rigidbody>().useGravity=true;
                FireBall2.GetComponent<Rigidbody>().useGravity=true;
                  FireBall3.GetComponent<Rigidbody>().useGravity=true;
                   FireBall4.GetComponent<Rigidbody>().useGravity=true;
                    FireBall5.GetComponent<Rigidbody>().useGravity=true;
          }
     }
}
