using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickStuff : MonoBehaviour
{
    public Image buttonBackground;
    public Spawner Move;
    public int upperLimitSpeed = 12;
    public int lowerLimitSpeed = 6;
    private bool clicked = false;

    public void ButtonClicked(){
        buttonBackground.color = Random.ColorHSV();
        Debug.Log("clickyli click click");
        Move.SpeedStuff();
        if (clicked){
            Move.moveSpeed = upperLimitSpeed;
            clicked = false;
        } else{
            Move.moveSpeed = lowerLimitSpeed;
            clicked = true;
        }
    }
    
}
