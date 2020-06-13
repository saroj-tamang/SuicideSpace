using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;
    public float lerprate;
    void Start()
    {
        //.......Distance between player and camera.......
        offset=player.transform.position-transform.position;
    }
    void Update()
    {
        Playerfollow();
    }
       //.......Camera follow to player with certain distance........
    void Playerfollow(){
        Vector3 pos=transform.position;
        Vector3 targetpos=player.transform.position-offset;
        pos=Vector3.Lerp(pos,targetpos,lerprate*Time.deltaTime);
        transform.position=pos;
    }
}
