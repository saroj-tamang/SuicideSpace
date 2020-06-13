using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject Temperature;
    public GameObject HealthBar;
    public GameObject OxygenBar;
    public static GameManager instance;
    public GameObject HotImage;
    public GameObject GasImage;
    public bool GameEnded;
    public bool GameStarted;
    public GameObject GameOverPanel;
    public GameObject GameStartPanel;
    public GameObject PausedPanel;
    public Text CoinCount;
    private int CoinCollectUpToNow,IntersititialAdsCount;
    public Text CountDownText;
    private int CoinUpdate=100;
    private int HighCountDown=20;
    public GameObject CoinRequire,CoinRequire1,CoinRequire2,CoinRequireInfinte;
    public GameObject WatchAdsButton;
    [HideInInspector]
    public bool isPaused;
    private bool OncePlayIntersititial=true;
    void Awake()
    {
        GameStarted=false;
        GameEnded=false;
        Time.timeScale=0;
        WatchAdsButton.SetActive(true);
        if (instance == null) {
            instance = this;
        } 
        InvokeRepeating("IncreaseTemp",1f,2f);
        InvokeRepeating("DecreaseHealth",1f,1f);
        InvokeRepeating("DecreaseOxygen",1f,2f); 

        if (PlayerPrefs.HasKey("CoinCollection"))
         {
         }
         else{
            PlayerPrefs.SetInt("CoinCollection",0);
         }; 
        if (PlayerPrefs.HasKey("IntersititialAdsCount"))
         {
         }
         else{
            PlayerPrefs.SetInt("IntersititialAdsCount",0);
         };   
   
    }
    void Start()
    { 
        CoinCollectUpToNow=PlayerPrefs.GetInt("CoinCollection");
        CoinCount.text=CoinCollectUpToNow.ToString();
        AdManager.instance.RequestInterstitial();
        AdManager.instance.RequestRewardBasedVideo();
        IntersititialAdsCount = PlayerPrefs.GetInt("IntersititialAdsCount");
        //AdManager.instance.RequestBanner();
         if (PlayerPrefs.HasKey("GameCheck"))
          {
             int currentGameCheck = PlayerPrefs.GetInt("GameCheck");
                 if(currentGameCheck==1){
                     GameStarted=true;
                     GameStartPanel.SetActive(false);
                     PlayerPrefs.SetInt("GameCheck",0);
                     AdManager.instance.DestroyBanner();
                     Time.timeScale=1;
                     OncePlayIntersititial=true;
                }
           };  
           
    }
    public void GameStart(){
        UserGuideManager.instance.SetFirstGuide(); 
        AdManager.instance.DestroyBanner();
        Time.timeScale=1;   
    }
    public void BeginGame(){
        GameStarted=true;    
    }
    public void GamePaused(){
        if(isPaused){
            Time.timeScale=1;
            isPaused=false;
            PausedPanel.SetActive(false);
        }else{
            Time.timeScale=0;
            isPaused=true;
            PausedPanel.SetActive(true);
        }
    }
    public void GameQuit(){
        SceneManager.LoadScene(0);
    }
    public void GameOver(){
        GameOverPanel.SetActive(true);
        UserGuideManager.instance.PercentagePlayerDisplay();
        InvokeRepeating("CountingDown",2f,2f);
     
        if(IntersititialAdsCount==0){
            PlayerPrefs.SetInt("IntersititialAdsCount",1);
        }
        else if(IntersititialAdsCount==1){
            PlayerPrefs.SetInt("IntersititialAdsCount",2);
        }
        else if(IntersititialAdsCount==2){
            PlayerPrefs.SetInt("IntersititialAdsCount",3);
        }
        else if(IntersititialAdsCount==3){
            PlayerPrefs.SetInt("IntersititialAdsCount",0);
            if(OncePlayIntersititial==true){
            AdManager.instance.ShowInterstitialAd();
            OncePlayIntersititial=false;
            }    
        };
        Debug.Log(IntersititialAdsCount);
    }
    public void CountingDown(){
        HighCountDown--;
        CountDownText.text=((float)HighCountDown*0.5f).ToString();
        if(HighCountDown==0){
           SceneManager.LoadScene(0);
           HighCountDown=20;
        }
    }
    public void GameRetry(){
        PlayerPrefs.SetInt("GameCheck",1);
        //GameOverPanel.SetActive(false); 
        SceneManager.LoadScene(0); 
    }

    public void CoinCounting(){
        CoinCollectUpToNow+=1;
        PlayerPrefs.SetInt("CoinCollection",CoinCollectUpToNow);
        CoinCount.text=CoinCollectUpToNow.ToString();
    }
    public void RewardedGame(){
        CancelInvoke("CountingDown");  
        HighCountDown=18;
        AdManager.instance.RequestInterstitial();
        CountDownText.text=((float)HighCountDown*0.5f).ToString();
        GameOverPanel.SetActive(false);
        PlayerScript.instance.PlayerOnDeadPosition();
        OxygenBar.transform.localScale = new Vector3(1f, 4f, 1f);
        HealthBar.transform.localScale = new Vector3(16f, 1.1138f, 1f);
        Temperature.transform.localScale = new Vector3(1f, 0f, 1f);
    }
    public void WatchAdsDisplayHandle(){
        WatchAdsButton.SetActive(false);
        Debug.Log("WatchVideo");
    }
  
    public void ChanceGame(){
     if(PlayerPrefs.GetInt("CoinCollection")>=CoinUpdate){
        int NewCoinCollection=PlayerPrefs.GetInt("CoinCollection")-CoinUpdate;
        PlayerPrefs.SetInt("CoinCollection",NewCoinCollection);
        CoinCount.text=NewCoinCollection.ToString();
        CancelInvoke("CountingDown");
        HighCountDown=18;
        AdManager.instance.RequestInterstitial();
        CountDownText.text=((float)HighCountDown*0.5f).ToString();
        GameOverPanel.SetActive(false);
        PlayerScript.instance.PlayerOnDeadPosition();
        OxygenBar.transform.localScale = new Vector3(1f, 4f, 1f);
        HealthBar.transform.localScale = new Vector3(16f, 1.1138f, 1f);
        Temperature.transform.localScale = new Vector3(1f, 0f, 1f);
        if(CoinUpdate==100){
             CoinUpdate=500;
        }
        else if(CoinUpdate==500){
             CoinUpdate=1000;
        }
        else if(CoinUpdate==1000){
            CoinUpdate=100000;
        }
        }
        else
        {
           if(CoinUpdate==100){
             CoinRequire.SetActive(true);
           }
           else if(CoinUpdate==500){
             CoinRequire1.SetActive(true);    
           }
           else if(CoinUpdate==1000){
             CoinRequire2.SetActive(true);
           }
           else if(CoinUpdate==100000){
             CoinRequireInfinte.SetActive(true);
           }
        }
    }
    public void StopIncreasingTemp(){   
        CancelInvoke("IncreaseTemp");
    }
    public void StopDecreasingGas(){
        CancelInvoke("DecreaseOxygen");
    }
    public void StartIncreasingTemp(){
        InvokeRepeating("IncreaseTemp",1f,2f);
    }
    public void StartDecreasingGas(){
        InvokeRepeating("DecreaseOxygen",1f,2f);
    }

    public void IncreaseTemp(){
        if(Temperature.transform.localScale.y<4 && GameStarted) {
            Temperature.transform.localScale += new Vector3(0, 0.1f, 0);
            HotImage.SetActive(false);
         }
         else if(Temperature.transform.localScale.y>=4){
            Temperature.transform.localScale += new Vector3(0, 0, 0);
            HotImage.SetActive(true);
        } 
    }

     public void DecreaseHealth(){
        if (Temperature.transform.localScale.y>=4||OxygenBar.transform.localScale.y<=0 ){
        if(HealthBar.transform.localScale.x>0){
            HealthBar.transform.localScale -= new Vector3(0.2f, 0, 0);
        }
        else{   
            HealthBar.transform.localScale -= new Vector3(0, 0, 0);
            GameOver();
        }
      }
    }
     public void DecreaseOxygen(){
         if(OxygenBar.transform.localScale.y>0 && GameStarted){
            OxygenBar.transform.localScale -= new Vector3(0, 0.1f, 0);
            GasImage.SetActive(false);
         }
         else if(OxygenBar.transform.localScale.y<=0){
            OxygenBar.transform.localScale -= new Vector3(0, 0, 0);
            GasImage.SetActive(true);
         }    
    }
    public void DecreaseTemp(){      
        InvokeRepeating("SubTemp",1f,1f);   
    }
    public void SubTemp(){
     if(Temperature.transform.localScale.y>0){
        Temperature.transform.localScale -= new Vector3(0, 0.5f, 0);
        }
      else{
           CancelInvoke ("SubTemp");  
        }  
    }
    public void IncreaseHealth(){
           InvokeRepeating("AddHealth",1f,1f);       
    }
    private void AddHealth(){
        if(HealthBar.transform.localScale.y<16){
             HealthBar.transform.localScale += new Vector3(2f, 0, 0);
        }
      else{
             CancelInvoke ("SubTemp");
        }
    }
    public void IncreaseOxygen(){
             InvokeRepeating("AddOxygen",1f,1f);
    }
    public void AddOxygen(){
         if(HealthBar.transform.localScale.y<4){
             OxygenBar.transform.localScale += new Vector3(0, 0.5f, 0);
         }
         else{
             CancelInvoke ("AddOxygen");
         }
    }

    public void CancelInvokefunction(){
        CancelInvoke ("AddHealth");
        CancelInvoke ("AddOxygen");
        CancelInvoke ("AddTemp");
    }

    public void DamageByEnemy(){
        if(Temperature.transform.localScale.y<4){
         Temperature.transform.localScale += new Vector3(0, 0.2f, 0);
        };
    }

    public void FullHealth(){
        if(HealthBar.transform.localScale.x<16){
         HealthBar.transform.localScale = new Vector3(16f, 1f, 1);
        }
    }
    public void FullTemp(){
         Temperature.transform.localScale = new Vector3(1f, 0f, 0);
         HotImage.SetActive(false);
    }
    public void FullOxygen(){
         OxygenBar.transform.localScale = new Vector3(1f, 4f, 0);
         GasImage.SetActive(false);
    }

}
