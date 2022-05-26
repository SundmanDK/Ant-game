//
// *Inspired by tutorial on how to make tooltips 
//   Auther : Game Dev Guide 
//   Channel: https://www.youtube.com/c/GameDevGuide
//
//   Source : https://www.youtube.com/watch?v=HXFoUGw7eKk&t=519s&ab_channel=GameDevGuide

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{
    private static LTDescr delay;
    public string content;
    public string header;

    public void OnPointerEnter(PointerEventData eventData){
        delay = LeanTween.delayedCall(0.5f, () =>
        {
            TooltipSystem.Show(content, header);
        });
    }

    public void OnPointerExit(PointerEventData eventData){
        LeanTween.cancel(delay.uniqueId);
        TooltipSystem.Hide();
    }
}
