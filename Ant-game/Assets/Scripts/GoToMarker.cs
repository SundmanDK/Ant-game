using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMarker : MonoBehaviour{

    Camera viewCamera;



    // Start is called before the first frame update
    void Start(){
        viewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            transform.position = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        }
    }
}
