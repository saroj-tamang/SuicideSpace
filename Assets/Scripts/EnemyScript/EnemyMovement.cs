using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
    private bool dirRight = true;
    public GameObject FirstEnemy;
    public float speed = 20f;
    void Start()
    {
        
    }
    void Update()
    {
        if (dirRight)
            FirstEnemy.transform.Translate (Vector3.right * speed * Time.deltaTime);
        else
            FirstEnemy.transform.Translate (-Vector3.right * speed * Time.deltaTime); 
        if(FirstEnemy.transform.position.x >= 4) {
            dirRight = false;
        }         
        if(FirstEnemy.transform.position.x <= -4) {
            dirRight = true;
        }  
    }
}
