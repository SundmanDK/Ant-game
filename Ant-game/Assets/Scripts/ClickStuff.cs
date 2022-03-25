using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickStuff : MonoBehaviour
{
    public Image buttonBackground;
    public Movement Move;

    public void ButtonClicked(){
        Move.moveSpeed = Move.moveSpeed + 10;
        buttonBackground.color = Random.ColorHSV();
        Debug.Log("clickyli click click");
    }
}
