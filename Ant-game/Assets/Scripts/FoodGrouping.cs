using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGrouping : MonoBehaviour{
    public int amountOfFood;
    private float scaleBasedOnFoodAmount;
    CircleCollider2D circleCol;


    // Start is called before the first frame update
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

    // Update is called once per frame
    void updateSize(){
        scaleBasedOnFoodAmount = 1 + (amountOfFood / 10);
        Vector3 newScale = new Vector3(scaleBasedOnFoodAmount, scaleBasedOnFoodAmount, 1);
        transform.localScale = newScale;
        //circleCol.radius = scaleBasedOnFoodAmount/2;
    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.layer == 0){
            amountOfFood -= 1;
            updateSize();
        }
    }
}
