using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;


public class GameoverInitializeScript : MonoBehaviour
{
    public GameObject OverlayMenu;
    public GameObject endMessege;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("death call");
        OverlayMenu.GetComponent<manageOverlayMenu>().GameOverfunction();
        Instantiate(endMessege, gameObject.transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
