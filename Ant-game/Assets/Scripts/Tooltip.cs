//
// *Inspired by tutorial on how to make tooltips 
//   Auther : Game Dev Guide 
//   Channel: https://www.youtube.com/c/GameDevGuide
//
//   Source : https://www.youtube.com/watch?v=HXFoUGw7eKk&t=519s&ab_channel=GameDevGuide

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour{
    public TextMeshProUGUI textHeader;
    public TextMeshProUGUI textContent;
    public LayoutElement LayoutElement;
    public int characterWrapLimit;
    public RectTransform rectTransform;

    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetText(string content, string header =""){
        if (string.IsNullOrEmpty(header)){
            textHeader.gameObject.SetActive(false);
        } else {
            textHeader.gameObject.SetActive(true);
            textHeader.text = header;
        }

        textContent.text = content;
        int headerLength = textHeader.text.Length;
        int contentLength = textContent.text.Length;

        LayoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
    }

    private void Update(){
        Vector2 position = Input.mousePosition;

        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        rectTransform.pivot = new Vector2(pivotX,pivotY); 
        transform.position = position;
    }
}
