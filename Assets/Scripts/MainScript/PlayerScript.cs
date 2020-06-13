using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;
    protected Joystick joystick;
    public GameObject PlayerParticle;
    public GameObject PlayerChancePlatform;
    public GameObject CongratulationPanel;
    protected bool jump;
    private bool onground;
    bool CoinsActive=true;
    Rigidbody rb;
    void Awake(){
        if (instance == null)
         {
            instance = this;
         } 
    }
    void Start()
    {
        onground=true;
        rb=GetComponent<Rigidbody>();
        joystick=FindObjectOfType<Joystick>(); 
    }
    void Update()
    {
         rb.velocity=new Vector3(joystick.Horizontal*10f,GetComponent<Rigidbody>().velocity.y,joystick.Vertical*10f); 
    }
    public void PlayerOnDeadPosition()
    {
         PlayerParticle.SetActive(true);
         Invoke("EndBlink",7.0f);
    }
    public void EndBlink()
    {
         PlayerParticle.SetActive(false);
         PlayerChancePlatform.SetActive(false);
         Invoke("EnableChancePlatform",2.0f);
    }
    public void EnableChancePlatform(){
         PlayerChancePlatform.SetActive(true);
    }
    public void jumpfunction(){
        if(!jump){
            GetComponent<Rigidbody>().velocity=Vector3.up*8f;
            jump=true; 
            onground=false;  
        }  
        else if(!onground) {
            GetComponent<Rigidbody>().velocity=Vector3.up*8f;
            onground=true;
        }
    }
    private void OnCollisionEnter(Collision collision){
        jump=false;  
        onground=true;
        if(collision.gameObject.tag=="HotCandle"){
            GameManager.instance.DamageByEnemy();
        };
        if(collision.gameObject.tag=="DeadPlatform"){
             GameManager.instance.GameOver(); 
             Vector3 newPos = new Vector3(0f,70f,transform.position.z);
             transform.position=newPos;
        }
    }
    void OnTriggerEnter(Collider col){
         if(col.gameObject.tag == "Oxygen"){
             GameManager.instance.FullOxygen();
             GameManager.instance.StopDecreasingGas();
             if (PlayerPrefs.HasKey("PreviousOxygenGuide")){
               int PreviousOxygenGuide = PlayerPrefs.GetInt("PreviousOxygenGuide");
               if(PreviousOxygenGuide==1){
               }
             }
             else{
             UserGuideManager.instance.Waterguide.SetActive(false);
             UserGuideManager.instance.Oxygenhealguide.SetActive(true);
             UserGuideManager.instance.Basicpanel.SetActive(true);
             UserGuideManager.instance.GuidePanel.SetActive(true);
             UserGuideManager.instance.GasHand.SetActive(true);
             PlayerPrefs.SetInt("PreviousOxygenGuide",1);
             Invoke("UserGuideHide",4f);
             }
         }
        else if(col.gameObject.tag == "Water"){
             GameManager.instance.FullTemp();
             GameManager.instance.StopIncreasingTemp();
             if (PlayerPrefs.HasKey("PreviousWaterGuide")){
              int PreviousWaterGuide = PlayerPrefs.GetInt("PreviousWaterGuide");
             if(PreviousWaterGuide==1){
               }
             }
             else{
             UserGuideManager.instance.Waterguide.SetActive(true);
             UserGuideManager.instance.Basicpanel.SetActive(true);
             UserGuideManager.instance.GuidePanel.SetActive(true);
             UserGuideManager.instance.Rocketguide.SetActive(false);
             UserGuideManager.instance.TempHand.SetActive(true);
             PlayerPrefs.SetInt("PreviousWaterGuide",1);
             Invoke("UserGuideHide",4f);
             }
         }
         else if(col.gameObject.tag == "HotCandle"){
              GameManager.instance.DamageByEnemy();
         }
         else if(col.gameObject.tag == "Coins"){
             Destroy(col.gameObject);
             if(CoinsActive==true){
                 CoinsActive=false;
                 GameManager.instance.CoinCounting();
                 Invoke("ActiveCoinStat",0.5f);
             }
         }
         else if(col.gameObject.tag == "Food"){
             GameManager.instance.FullHealth();
             Destroy(col.gameObject);
             if (PlayerPrefs.HasKey("PreviousFoodGuide")){
              int PreviousFoodGuide = PlayerPrefs.GetInt("PreviousFoodGuide");
               if(PreviousFoodGuide==1){
               }
             }
             else{
             UserGuideManager.instance.Oxygenhealguide.SetActive(false);
             UserGuideManager.instance.Healthhealguide.SetActive(true);
             UserGuideManager.instance.Basicpanel.SetActive(true);
             UserGuideManager.instance.GuidePanel.SetActive(true);
             UserGuideManager.instance.HealthHand.SetActive(true);
             PlayerPrefs.SetInt("PreviousFoodGuide",1);
             Invoke("UserGuideHide",4f);
             }
         }
         else if(col.gameObject.tag == "DeadPlatform"){
             GameManager.instance.GameOver(); 
              Vector3 newPos = new Vector3(0f,70f,transform.position.z);
              transform.position=newPos;
         }
         else if(col.gameObject.tag == "BoxGuide"){
             if (PlayerPrefs.HasKey("PreviousBoxGuide")){
              int PreviousBoxGuide = PlayerPrefs.GetInt("PreviousBoxGuide");
               if(PreviousBoxGuide==1){
                    Destroy(col.gameObject);
               }
               }
               else{
             UserGuideManager.instance.Boxguide.SetActive(true);
             UserGuideManager.instance.Basicpanel.SetActive(true);
             UserGuideManager.instance.GuidePanel.SetActive(true);
             Destroy(col.gameObject);
             PlayerPrefs.SetInt("PreviousBoxGuide",1);
             Invoke("UserGuideHide",4f);
               }
         }
         else if(col.gameObject.tag == "RocketGuide"){
             if (PlayerPrefs.HasKey("PreviousRocketGuide")){
              int PreviousRocketGuide = PlayerPrefs.GetInt("PreviousRocketGuide");
               if(PreviousRocketGuide==1){
                   Destroy(col.gameObject);
               }
               }
               else{
             UserGuideManager.instance.Boxguide.SetActive(false);
             UserGuideManager.instance.Rocketguide.SetActive(true);
             UserGuideManager.instance.Basicpanel.SetActive(true);
             UserGuideManager.instance.GuidePanel.SetActive(true);
             Destroy(col.gameObject);
             PlayerPrefs.SetInt("PreviousRocketGuide",1);
             Invoke("UserGuideHide",4f);
               }
         }
         else if(col.gameObject.tag == "FinishPlatform"){
             CongratulationPanel.SetActive(true);
             Invoke("RetryGameAgain",10f);
         }
     }
    public void RetryGameAgain(){
        SceneManager.LoadScene(0); 
     }
     void UserGuideHide(){
         UserGuideManager.instance.GuidePanel.SetActive(false);
         UserGuideManager.instance.TempHand.SetActive(false);
         UserGuideManager.instance.GasHand.SetActive(false);
         UserGuideManager.instance.HealthHand.SetActive(false);
     }
     void ActiveCoinStat(){
         CoinsActive=true;
     }
    void OnTriggerExit(Collider coll)
    {
        if(coll.gameObject.tag == "Oxygen"){
           GameManager.instance.CancelInvokefunction();
           GameManager.instance.StartDecreasingGas();
         }
        else if(coll.gameObject.tag == "Water"){
            GameManager.instance.CancelInvokefunction();
            GameManager.instance.StartIncreasingTemp();
        }
        else if(coll.gameObject.tag == "Food"){
            GameManager.instance.CancelInvokefunction();
            Destroy(coll.gameObject);
        }
    }
}

