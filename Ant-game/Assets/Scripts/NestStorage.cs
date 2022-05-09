using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestStorage : MonoBehaviour{
    public int food;
    public int score;
    public int gold;
    public int accountedFood;

    // Start is called before the first frame update
    void Start() {
        food  = 0;
        accountedFood = 0;
        score = 0;
        gold  = 0;


  

    }


    void Update(){
        if (food != accountedFood)
        {
            accountedFood = food;
            UpdateScore();
            UpdateGold();
       
                     Debug.Log("The food" + food);
                     Debug.Log("The gold" + gold);
                     Debug.Log("The score" + score);
        }
    }

    void UpdateScore(){
        score = food*10;
   
    }
    void UpdateGold(){
        gold += 10;
    }
}
