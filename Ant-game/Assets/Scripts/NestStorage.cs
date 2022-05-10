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

    public TMPro.TextMeshProUGUI textDisplayFood;
    public TextMeshPro FloatingText;
    private Color numberColor;

    // Start is called before the first frame update
    void Start() {
        food  = 0;
        oldFood = 0;
        score = 0;
        gold  = 0;
      
        FloatingText.text = "10";
        Color numberColor = new Color(255, 255, 255);
        textDisplayFood.color = numberColor;


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

    void CallFloatingText()
        {
        Instantiate(FloatingText,new Vector3(0f,0f,0f),Quaternion.identity);


        }
   
}
