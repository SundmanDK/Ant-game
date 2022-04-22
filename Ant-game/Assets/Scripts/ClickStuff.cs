using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickStuff : MonoBehaviour
{
    public Spawner Move;
    public int upperLimitSpeed = 12;
    public int lowerLimitSpeed = 6;
    private bool clicked = false;
    public NestStorage nestStorage;
    private int food;

    public void ButtonClicked(){
        //Debug.Log("clickyli click click");
        food = nestStorage.food;
        if (clicked && food >= 10){ 
            Move.moveSpeed = lowerLimitSpeed;
            clicked = false;
            nestStorage.food -= 10;
            //Debug.Log("clicked false speed 6");
        } else if (!clicked && food >= 10){
            Move.moveSpeed = upperLimitSpeed;
            clicked = true;
            nestStorage.food -= 10;
            //Debug.Log("clicked true speed 12");
        }
        Move.SpeedStuff();
    }
    
}
