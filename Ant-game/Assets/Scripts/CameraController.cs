using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour{
    
    private float panSpeed = 0.1f;
    private float tuneBorderRight = 75f;
    private float tuneBorderLeft  = 75f;
    private float tuneBorderUp    = 75f;
    private float tuneBorderDown  = 75f;

    private float boundsCameraRight  =  75f;
    private float boundsCameraLeft   = -75f;
    private float boundsCameraTop    =  50f;
    private float boundsCameraBottom = -50f;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        /*Debug.Log("these are the mousePos.x:" + mousePos.x);
          Debug.Log("these are the mousePos.y:" + mousePos.y);
          Debug.Log("these are the position.x:" + transform.position.x);
          Debug.Log("these are the position.y:" + transform.position.y);*/
        if (transform.position.x <= boundsCameraRight && Input.GetKey(KeyCode.D) || transform.position.x <= boundsCameraRight && mousePos.x >= Screen.width-tuneBorderRight ) {
            transform.Translate(panSpeed, 0f, 0f); 
        }
        if (transform.position.x >= boundsCameraLeft && Input.GetKey(KeyCode.A)  || transform.position.x >= boundsCameraLeft && mousePos.x <= 0+tuneBorderLeft )   {
            transform.Translate(-panSpeed, 0f, 0f);}
        if (transform.position.y <= boundsCameraTop  && Input.GetKey(KeyCode.W)  || transform.position.y <= boundsCameraTop  && mousePos.y >= Screen.height-tuneBorderUp ) {
            transform.Translate(0f, panSpeed, 0f);}
        if (transform.position.y >= boundsCameraBottom && Input.GetKey(KeyCode.S)|| transform.position.y >= boundsCameraBottom && mousePos.y <= 0+tuneBorderRight) {
            transform.Translate(0f, -panSpeed, 0f);}
       
    }
    
}
