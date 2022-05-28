using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpriteChanger : MonoBehaviour{
    public Sprite deactiveButtonSprite;
    public Sprite enabledButtonSprite;

    public void ButtonOnVisual(){
        this.GetComponent<Image>().sprite = enabledButtonSprite;
    }
    
    public void ButtonOffVisual(){
        this.GetComponent<Image>().sprite = deactiveButtonSprite;
    }
}
