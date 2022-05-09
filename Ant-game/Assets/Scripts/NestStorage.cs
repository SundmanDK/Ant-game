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
    private Color numberColor;

    // Start is called before the first frame update
    void Start() {
        food  = 0;
        oldFood = 0;
        score = 0;
        gold  = 0;

        Color numberColor = new Color(0, 0, 0);
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
}
