using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGrouping : MonoBehaviour{
    public int amountOfFood;
    private float scaleBasedOnFoodAmount;
    CircleCollider2D circleCol;

    void Start(){
        circleCol = GetComponent<CircleCollider2D>();

        amountOfFood = Random.Range(50, 250);
        updateSize();
    }

    void FixedUpdate(){
        if (amountOfFood <= 0){
            Destroy(gameObject);
        }
    }

    public void updateSize(){
        scaleBasedOnFoodAmount = 1 + (amountOfFood / 10);
        Vector3 newScale = new Vector3(scaleBasedOnFoodAmount, scaleBasedOnFoodAmount, 1);
        transform.localScale = newScale;
    }

}
