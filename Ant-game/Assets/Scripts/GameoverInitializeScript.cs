using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverInitializeScript : MonoBehaviour{
    public GameObject endMessege;
    public GameObject winMessege;
    public GameObject ui;

    public void Lost(){
    
        ui.gameObject.SetActive(false);
        Instantiate(endMessege, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void Win(){
        ui.gameObject.SetActive(false);
        Instantiate(winMessege, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
