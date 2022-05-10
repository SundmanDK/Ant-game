using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickStuff : MonoBehaviour{
    public Spawner Move;
    public int speedLimit = 20;
    public NestStorage nestStorage;
    private int food;
    private int speed;

    public void ButtonClicked(){
        food = nestStorage.food;
        speed = Move.moveSpeed;
        if (food >= 10 && speed < speedLimit){ 
            Move.moveSpeed += 2;
            nestStorage.food -= 10;
            Move.SpeedStuff();
            Debug.Log("does it work?");
        } else if(food < 10){
            Debug.Log("you dont have enogh food");
        } else{
            Debug.Log("you can't go higher you've reached the speed limit");
        }
    }
    
}
