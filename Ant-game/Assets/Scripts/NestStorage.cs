using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NestStorage : MonoBehaviour{
    public int food;
    private int oldFood;
    public int score;
    public int gold;
    public int maxHealth;
    public int currentHealth;

    public Button spawnButton;
    public Button healthButton;
    public Button healButton;

    public TextMeshPro textDisplayFood;
    public TextMeshPro FloatingText;
    public GameObject Ant;
    public GameObject ControllableAnt;
    private ControlableAnt CA;
    
    public Color numberWhiteColor;
    public Color numberRedColor;
   


    // Start is called before the first frame update
    void Start() {
        food    = 0;
        oldFood = 0;
        score   = 0;
        gold    = 0;
         CA = ControllableAnt.GetComponent<ControlableAnt>();

        FloatingText.text     = "10";
        Color numberWhiteColor= new Color(255,255,255);
        Color numberRedColor  = new Color(255,0,0);

        Button spawnBtn = spawnButton.GetComponent<Button>();
        spawnBtn.onClick.AddListener(checkSpawnButton);


        Button healBtn = healButton.GetComponent<Button>();
        healBtn.onClick.AddListener(checkHealButton);

        Button healthBtn = healthButton.GetComponent<Button>();
        healthBtn.onClick.AddListener(checkHealthButton);
    }


    void Update(){
        if (food != oldFood) {
        everyFood();
        }
        oldFood = food;
    }

    void everyFood()
    {
        CallFloatingText();
        UpdateGold();
        UpdateScore();
    
    }

    void UpdateScore(){
        score = food*10;
   
    }
    void UpdateGold(){
        gold += 10;
        textDisplayFood.text = gold.ToString();
    }

    void CallFloatingText(){
        Instantiate(FloatingText,new Vector3(0f,0f,0f),Quaternion.identity);

    }
   void checkSpawnButton()
    {
        if (gold >= 250){
        executeSpawnButton();
        }else failedMoney();
    }
    void executeSpawnButton()
    {
        gold = gold - 250;
        Instantiate(Ant, new Vector3(0f, 0f, 0f), Quaternion.identity, gameObject.transform);
        textDisplayFood.text = gold.ToString();
    }
    

    void checkHealButton()
    {
        if (gold >= 250)
        {
            executeHealButton();
        }else failedMoney();
    }
    void executeHealButton()
    {
        gold = gold - 250;
     if(CA.currentHealth<CA.maxHealth){ CA.currentHealth = CA.currentHealth + 2;}
        CA.updateHealthbar();
        textDisplayFood.text = gold.ToString();
    }

    void checkHealthButton()
    {
        
        if (gold >= 250)
        {
            executeHealthButton();
        }else failedMoney();
    }
    void executeHealthButton()
    {
        gold = gold - 250;
   CA.maxHealth = CA.maxHealth + 2;
        CA.updateHealthbar();
        textDisplayFood.text = gold.ToString();
    }

    void failedMoney()
    {
        textDisplayFood.color = numberRedColor;
        textDisplayFood.alpha = 255f;
        textDisplayFood.text = gold.ToString();
       Invoke("changeColorBack",1);

    }
    void changeColorBack(){
 textDisplayFood.color = numberWhiteColor;
        textDisplayFood.alpha = 255f;
    }
    }
    
