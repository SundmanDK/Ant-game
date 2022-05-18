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
    private int armorCostFactor;
    private int healthCostFactor;
    private int damageCostFactor;

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

    Text antBuyRef;
    string antBuyText;
    Text healRef;
    string healText;
    Text healthRef;
    string healthText;
    Text damageRef;
    string damageText;
    Text armorRef;
    string armorText;


    // Start is called before the first frame update
    void Start(){
        food = 0;
        oldFood = 0;
        score = 0;
        gold = 0;
        antCostFactor = 1;
        armorCostFactor = 1;
        healthCostFactor = 1;
        damageCostFactor = 1;


       
        AC = ControllableAnt.GetComponent<AntCombat>();


        Color numberWhiteColor = new Color(255, 255, 255);
        Color numberRedColor = new Color(255, 0, 0);


        FloatingText.text = "10";

        Button spawnBtn = spawnButton.GetComponent<Button>();
        antBuyRef = spawnButton.transform.GetChild(0).gameObject.GetComponent<Text>();
        antBuyText = antBuyRef.text;
        updateButtonText(antBuyRef, antBuyText, 5 * antCostFactor);
        spawnBtn.onClick.AddListener(checkSpawnButton);


        Button healBtn = healButton.GetComponent<Button>();
        healRef = healBtn.transform.GetChild(0).gameObject.GetComponent<Text>();
        healText = healRef.text;
        updateButtonText(healRef, healText, 20);
        healBtn.onClick.AddListener(checkHealButton);

        Button healthBtn = healthButton.GetComponent<Button>();
        healthRef = healthBtn.transform.GetChild(0).gameObject.GetComponent<Text>();
        healthText = healthRef.text;
        updateButtonText(healthRef, healthText, 20);
        healthBtn.onClick.AddListener(checkHealthButton);

        Button damageBtn = damageButton.GetComponent<Button>();
        damageRef = damageBtn.transform.GetChild(0).gameObject.GetComponent<Text>();
        damageText = damageRef.text;
        updateButtonText(damageRef, damageText, 20);
        damageBtn.onClick.AddListener(checkDamageButton);

        Button armorBtn = armorButton.GetComponent<Button>();
        armorRef = armorBtn.transform.GetChild(0).gameObject.GetComponent<Text>();
        armorText = armorRef.text;
        updateButtonText(armorRef, armorText, 20);
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

    void everyFood() {
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
        cost = calculateCost(5, antCostFactor);
        if (gold >= (cost)){
            executeSpawnButton(cost);
            antCostFactor += 1;
            updateButtonText(antBuyRef, antBuyText, calculateCost(5, antCostFactor));
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
        cost = calculateCost(20, healthCostFactor);
        if (gold >= cost){
            executeHealthButton(cost);
            healthCostFactor += 1;
            updateButtonText(healthRef, healthText, calculateCost(20, healthCostFactor));
        } else failedMoney();
    }
    void executeHealthButton(int cost){
        pay(cost);
        AC.maxHealth += 50;
        AC.heal(50);
    }

    void checkArmorButton(){
        int cost = calculateCost(20, armorCostFactor);
        if (gold >= cost){
            executeArmorButton(cost);
            armorCostFactor += 1;
            updateButtonText(armorRef, armorText, calculateCost(20, armorCostFactor));
        } else failedMoney();
    }
    void executeArmorButton(int cost){
        pay(cost);
        AC.armor += 10;
    }

    void checkDamageButton(){
        int cost = calculateCost(20, damageCostFactor);
        if (gold >= cost){
            executeDamageButton(cost);
            damageCostFactor += 1;
            updateButtonText(damageRef, damageText, calculateCost(20, damageCostFactor));
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

    void updateButtonText(Text reference, string buttonText, int cost){
        reference.text = buttonText + " ( " + cost +" )";
    }

    int calculateCost(int startCost, int factor){
        return startCost * factor;
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