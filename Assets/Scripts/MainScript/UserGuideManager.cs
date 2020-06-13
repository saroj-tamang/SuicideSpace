using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserGuideManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject GuidePanel;
    public GameObject FirstPanel;
    public GameObject Basicpanel;
    public GameObject TempGuide;
    public GameObject Gasguide;
    public GameObject Healthguide;
    public GameObject TempHand;
    public GameObject GasHand;
    public GameObject HealthHand;
    public GameObject Boxguide;
    public GameObject Rocketguide;
    public GameObject Waterguide;
    public GameObject Oxygenhealguide;
    public GameObject Healthhealguide;
    public GameObject LevelPercentage;
    private float LevelPercentagePlayer;
    public Text PercentagePlayer;
    public static UserGuideManager instance;

    void Awake(){
        if (instance == null) {
            instance = this;
        } 
    }
    void Start()
    {
    }
    void Update()
    {
        LevelPercentagePlayer=(float)Player.transform.position.z*0.0008f;
        LevelPercentage.transform.localScale = new Vector3(LevelPercentagePlayer, 0.4942839f, 0.4077913f);;
    }
    public void PercentagePlayerDisplay(){
        float NewPercentagePlayer=Mathf.Round(LevelPercentagePlayer*25f);
        PercentagePlayer.text=NewPercentagePlayer.ToString()+"%";
    }  
    public void SkipButtonPress(){
         if (TempGuide.activeInHierarchy){
             TempGuide.SetActive(false);
             TempHand.SetActive(false);
             Gasguide.SetActive(true);
             GasHand.SetActive(true);
         }
         else if(Gasguide.activeInHierarchy){
             Gasguide.SetActive(false);
             GasHand.SetActive(false);
             Healthguide.SetActive(true);
             HealthHand.SetActive(true);
         }
         else if(Healthguide.activeInHierarchy){
             Healthguide.SetActive(false);
             HealthHand.SetActive(false); 
             FirstPanel.SetActive(false);
             GuidePanel.SetActive(false);
             GameManager.instance.BeginGame();
         }
    }
    public void SetFirstGuide(){
        Invoke("StartGuide",1f);  
    }
    void StartGuide(){
        if (PlayerPrefs.HasKey("PreviousStart")){
            int currentPreviousStart = PlayerPrefs.GetInt("PreviousStart");
               if(currentPreviousStart==1){
                   GuidePanel.SetActive(false);
                   GameManager.instance.BeginGame();                 
            }
        }
        else{
           GuidePanel.SetActive(true);
           FirstPanel.SetActive(true);
           TempGuide.SetActive(true);
           TempHand.SetActive(true);
           PlayerPrefs.SetInt("PreviousStart",1);
       }
    }
}
