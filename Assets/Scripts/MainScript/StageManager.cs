using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject BeginnerPlatform, FirstPlatform,SecondPlatform,LastPlatfrom,ZigzagPlaform;
    public GameObject firstPart,SecondPart,ThirdPart,FourthPart,FifthPart,SixthPart;
    public GameObject finalpart,finalpart2,finalpart3,lastpart,finalsnakespace,endingpart,finishplatform;
    public GameObject Magmasurface1,Magmasurface2;
    public GameObject MagmaPlatform;
    public GameObject fireballprefabs;
    public GameObject Box1,Box2,Box3,Box4,Box5,Box6;
    public GameObject Rocket1,Rocket2;
    private int Randomnumber;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject FirstSectionPart;
    private GameObject obj1,obj2,obj3,obj4;
    void Awake(){
        Randomnumber=Random.Range(0, 3);
    }
    void Start()
    {
        InvokeRepeating("MagmaPlatformer",0.002f,0.002f);
        InvokeRepeating("CreatePrefab",5f,5f); 
        InvokeRepeating("StageManagment",2f,2f);

        if(Randomnumber==0){
           obj1=(GameObject)Instantiate(prefab1, new Vector3(0, 0, 135), Quaternion.identity);
           obj2=(GameObject)Instantiate(prefab2, new Vector3(-4.618781f, 4, 474.65f), Quaternion.identity);
           obj3=(GameObject)Instantiate(prefab3, new Vector3(0.064437f, 16f, 1457.57f), Quaternion.identity);
           InvokeRepeating("Random1",2f,2f);
        }
        else if(Randomnumber==1){
           obj1=(GameObject)Instantiate(prefab1, new Vector3(0, 4.2f, 496.5f), Quaternion.identity);
           obj2=(GameObject)Instantiate(prefab2, new Vector3(-4.618781f, 11f, 1434.37f), Quaternion.identity);
           obj3=(GameObject)Instantiate(prefab3, new Vector3(0.064437f, 10.2f, 136.1f), Quaternion.identity);
           InvokeRepeating("Random2",2f,2f);

        }
        else if(Randomnumber==2){
           obj1=(GameObject)Instantiate(prefab1, new Vector3(0, 9.08f, 1456.12f), Quaternion.identity);
           obj2=(GameObject)Instantiate(prefab2, new Vector3(-4.618781f, 4, 113.7f), Quaternion.identity);
           obj3=(GameObject)Instantiate(prefab3, new Vector3(0.064437f, 8.8f, 498.3f), Quaternion.identity);
           InvokeRepeating("Random3",2f,2f);

        }   
    }
    void Update()
    {
    }

    public void CreatePrefab()
    {
        obj4=(GameObject)Instantiate(fireballprefabs, fireballprefabs.transform.position, Quaternion.identity);
    }

    public void Random1(){
        if(Player.transform.position.z>80 && Player.transform.position.z<150){
             obj1.SetActive(true);
        }
        else if(Player.transform.position.z>300 && Player.transform.position.z<400){
             obj1.SetActive(false);
        }
        else if(Player.transform.position.z>450 && Player.transform.position.z<550){
             obj2.SetActive(true);
        }
        else if(Player.transform.position.z>670 && Player.transform.position.z<750){
             obj2.SetActive(false);
        }
        else if(Player.transform.position.z>1400 && Player.transform.position.z<1500){
             obj3.SetActive(true);
        }
        else if(Player.transform.position.z>1630 && Player.transform.position.z<1730){
             obj3.SetActive(false);
        }
    }
    public void Random2(){
        if(Player.transform.position.z>80 && Player.transform.position.z<150){
             obj3.SetActive(true);
        }
        else if(Player.transform.position.z>300 && Player.transform.position.z<400){
             obj3.SetActive(false);
        }
        else if(Player.transform.position.z>450 && Player.transform.position.z<550){
             obj1.SetActive(true);
        }
        else if(Player.transform.position.z>670 && Player.transform.position.z<750){
             obj1.SetActive(false);
        }
        else if(Player.transform.position.z>1400 && Player.transform.position.z<1500){
             obj2.SetActive(true);
        }
        else if(Player.transform.position.z>1630 && Player.transform.position.z<1730){
             obj2.SetActive(false);
        }
    }
    public void Random3(){
        if(Player.transform.position.z>80 && Player.transform.position.z<150){
             obj2.SetActive(true);
        }
        else if(Player.transform.position.z>300 && Player.transform.position.z<400){
             obj2.SetActive(false);
        }
        else if(Player.transform.position.z>450 && Player.transform.position.z<550){
             obj3.SetActive(true);
        }
        else if(Player.transform.position.z>670 && Player.transform.position.z<750){
             obj3.SetActive(false);
        }
        else if(Player.transform.position.z>1400 && Player.transform.position.z<1500){
             obj1.SetActive(true);
        }
        else if(Player.transform.position.z>1630 && Player.transform.position.z<1730){
             obj1.SetActive(false);
        }
    }
    public void MagmaPlatformer()
    {
        MagmaPlatform.transform.Rotate(0f, 0.1f, 0f, Space.Self);
    } 
    public void StageManagment(){
        if(Player.transform.position.z>150 && Player.transform.position.z<250){
            BeginnerPlatform.SetActive(false);
            Box1.SetActive(false);
            Rocket1.SetActive(false);
            FirstPlatform.SetActive(true);
        }
        else if(Player.transform.position.z>520 && Player.transform.position.z<600){
            FirstPlatform.SetActive(false);
            SecondPlatform.SetActive(true);
            Rocket2.SetActive(true);
        }
        else if(Player.transform.position.z>950 && Player.transform.position.z<1050){
            LastPlatfrom.SetActive(true);
            Box2.SetActive(true);
            Box3.SetActive(true);
            Box4.SetActive(true);
            obj4.SetActive(true);
            ZigzagPlaform.SetActive(true);
        }
        else if(Player.transform.position.z>1100 && Player.transform.position.z<1200){
            SecondPlatform.SetActive(false);
            Rocket2.SetActive(false);
        }
        else if(Player.transform.position.z>1450 && Player.transform.position.z<1550){
            firstPart.SetActive(true);
        }
        else if(Player.transform.position.z>1600 && Player.transform.position.z<1650){
            LastPlatfrom.SetActive(false);
            Box2.SetActive(false);
            Box3.SetActive(false);
            Box4.SetActive(false);
            obj4.SetActive(false);
            ZigzagPlaform.SetActive(false);
        }
        else if(Player.transform.position.z>2000 && Player.transform.position.z<2100){
            SecondPart.SetActive(true);
        }
        else if(Player.transform.position.z>2250 && Player.transform.position.z<2350){
            firstPart.SetActive(false);
            ThirdPart.SetActive(true);
            Box5.SetActive(true);
        }
        else if(Player.transform.position.z>2650 && Player.transform.position.z<2750){
            FourthPart.SetActive(true);
            SecondPart.SetActive(false);
        }
        else if(Player.transform.position.z>2900 && Player.transform.position.z<3000){
            FifthPart.SetActive(true);
            ThirdPart.SetActive(false);
            Box5.SetActive(false);
        }
        else if(Player.transform.position.z>3100 && Player.transform.position.z<3200){
            FourthPart.SetActive(false);
        }
        else if(Player.transform.position.z>3450 && Player.transform.position.z<3550){
            SixthPart.SetActive(true);  
        }
        else if(Player.transform.position.z>3600 && Player.transform.position.z<3700){
            FifthPart.SetActive(false);  
        }
        else if(Player.transform.position.z>3800 && Player.transform.position.z<3900){
            finalpart.SetActive(true);
        }
        else if(Player.transform.position.z>4050 && Player.transform.position.z<4150){
            SixthPart.SetActive(false);
            finalpart2.SetActive(true);
            Box6.SetActive(true);
        }
        else if(Player.transform.position.z>4170 && Player.transform.position.z<4230){
            finalpart.SetActive(false);
            finalpart3.SetActive(true);
        }
        else if(Player.transform.position.z>4300 && Player.transform.position.z<4400){
            Box6.SetActive(false);
            finalpart2.SetActive(false);
            lastpart.SetActive(true);
        }
        else if(Player.transform.position.z>4450 && Player.transform.position.z<4550){
            finalpart3.SetActive(false);
            finalsnakespace.SetActive(true);
        }
        else if(Player.transform.position.z>4620 && Player.transform.position.z<4690){
            lastpart.SetActive(false);
            endingpart.SetActive(true);
        }
        else if(Player.transform.position.z>4850 && Player.transform.position.z<4950){
            finalsnakespace.SetActive(false);
            finishplatform.SetActive(true);
        }
        else if(Player.transform.position.z>4980 && Player.transform.position.z<5100){
            endingpart.SetActive(false);
        }
        
    }
}
