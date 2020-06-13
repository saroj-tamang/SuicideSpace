using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerScript : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("MoveSpinner",0.02f,0.02f);
    }
    void MoveSpinner(){
        gameObject.transform.Rotate(0.0f, 0.0f, 1f, Space.Self);
    }
}
