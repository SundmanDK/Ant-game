using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMarker : MonoBehaviour{
    Camera viewCamera;

    void Start(){
        viewCamera = Camera.main;
    }

    void Update() {
        Vector3 mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0) && mousePos.y >= 230){
            transform.position = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        }
        
    }
}
