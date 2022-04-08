using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickStuff : MonoBehaviour
{
    public Image buttonBackground;
    public Spawner Move;
    private bool clicked = false;

    public void ButtonClicked(){
        buttonBackground.color = Random.ColorHSV();
        Debug.Log("clickyli click click");
        Move.SpeedStuff();
        if (clicked){
            Move.moveSpeed = 40;
            clicked = false;
        } else{
            Move.moveSpeed = 12;
            clicked = true;
        }
    }
    
}
