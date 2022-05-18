using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NestStorage : MonoBehaviour
{
    public int food;
    private int oldFood;
    public int score;
    public int gold;
    private int cost;
    public int maxHealth;
    public int currentHealth;
    private int antCostFactor;

    public Button spawnButton;
    public Button healthButton;
    public Button healButton;
    public Button damageButton;
    public Button armorButton;

    public TextMeshProUGUI textDisplayFood;
    public TextMeshPro FloatingText;
    public GameObject Ant;
    public GameObject ControllableAnt;
    private AntCombat AC;
    

    public Color numberWhiteColor;
    public Color numberRedColor;

    TooltipTrigger antTip;
    string antToolTip;

    // Start is called before the first frame update
    void Start(){
        food = 0;
        oldFood = 0;
        score = 0;
        gold = 0;
        antCostFactor = 1;

       
        AC = ControllableAnt.GetComponent<AntCombat>();


        Color numberWhiteColor = new Color(255, 255, 255);
        Color numberRedColor = new Color(255, 0, 0);


        FloatingText.text = "10";

        Button spawnBtn = spawnButton.GetComponent<Button>();
        antTip = spawnButton.GetComponent<TooltipTrigger>();
        antToolTip = antTip.content;
        antTip.content = antToolTip + " Costs: " + (5 * antCostFactor);
        spawnBtn.onClick.AddListener(checkSpawnButton);


        Button healBtn = healButton.GetComponent<Button>();
        healBtn.onClick.AddListener(checkHealButton);

        Button healthBtn = healthButton.GetComponent<Button>();
        healthBtn.onClick.AddListener(checkHealthButton);

        Button damageBtn = damageButton.GetComponent<Button>();
        damageBtn.onClick.AddListener(checkDamageButton);

        Button armorBtn = armorButton.GetComponent<Button>();
        armorBtn.onClick.AddListener(checkArmorButton);
    }

    void Update()
    {
        if (food != oldFood)
        {
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

    void UpdateScore()
    {
        score = food * 10;

    }
    void UpdateGold()
    {
        gold += 10;
        textDisplayFood.text = gold.ToString();
    }

    void CallFloatingText(){
        Instantiate(FloatingText, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }

    void checkSpawnButton(){
        if (gold >= (5 * antCostFactor)){
            executeSpawnButton(5 * antCostFactor);
            antCostFactor += 1;
            antTip.content = antToolTip + " Costs: " + (5 * antCostFactor); 
        } else failedMoney();
    }
    void executeSpawnButton(int cost){
        pay(cost);
        Instantiate(Ant, new Vector3(0f, 0f, 0f), Quaternion.identity, gameObject.transform);
    }

    void checkHealButton(){
        cost = 20;
        if (gold >= cost && AC.health < AC.maxHealth){
            executeHealButton(cost);
        } else failedMoney();
    }
    void executeHealButton(int cost){
        pay(cost);
        AC.heal(2);
    }
    
    void checkHealthButton(){
        cost = 20;
        if (gold >= cost){
            executeHealthButton(cost);
        } else failedMoney();
    }
    void executeHealthButton(int cost){
        pay(cost);
        AC.maxHealth += 50;
        AC.heal(50);
    }

    void checkArmorButton(){
        int cost = 20;
        if (gold >= cost){
            executeArmorButton(cost);
        } else failedMoney();
    }
    void executeArmorButton(int cost){
        pay(cost);
        AC.armor += 10;
    }

    void checkDamageButton(){
        int cost = 20;
        if (gold >= cost){
            executeDamageButton(cost);
        } else failedMoney();
    }
    void executeDamageButton(int cost){
        pay(cost);
        AC.damage += 5;
    }

    void pay(int cost){
        gold -= cost;
        textDisplayFood.text = gold.ToString();
    }


    void failedMoney()
    {
        textDisplayFood.color = numberRedColor;
        textDisplayFood.alpha = 255f;
        textDisplayFood.text = gold.ToString();
        Invoke("changeColorBack", 1);

    }
    void changeColorBack()
    {
        textDisplayFood.color = numberWhiteColor;
        textDisplayFood.alpha = 255f;
    }
}