using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBoarders : MonoBehaviour
{
    
    public GameObject leftBoarder;
    public GameObject rightBoarder;
    public GameObject topBoarder;
    public GameObject bottomBoarder;

    public Vector3 newPositionLeftBoarder;
    public Vector3 newPositionRightBoarder;
    public Vector3 newPositionTopBoarder;
    public Vector3 newPositionBottomBoarder;

    public Vector3 newscaleLeftBoarder;
    public Vector3 newscaleRightBoarder;
    public Vector3 newscaleTopBoarder;
    public Vector3 newscaleBottomBoarder;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    public void whenButtonClicked2(){
        if (leftBoarder.activeInHierarchy == true)
            leftBoarder.SetActive(false);
        else
            leftBoarder.SetActive(true);
    }
    
    */
    public void whenButtonClicked(){

        leftBoarder.transform.position = new Vector3(-118f, 4.9f, 0f);
        rightBoarder.transform.position = new Vector3(81f, 5.2f, 0f);
        topBoarder.transform.position = new Vector3(-18.5f, 59.8f, 0f);
        bottomBoarder.transform.position = new Vector3(-18.5f, -50f, 0f);

        leftBoarder.transform.localScale = new Vector3(1f , 110f, 1f);
        rightBoarder.transform.localScale = new Vector3(1f, 110f, 1f);
        topBoarder.transform.localScale = new Vector3(200f, 1f, 1f);
        bottomBoarder.transform.localScale = new Vector3(200f, 1f, 1f);
    }
}
