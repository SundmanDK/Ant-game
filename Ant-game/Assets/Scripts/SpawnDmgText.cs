using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class SpawnDmgText : MonoBehaviour
{
    //public TextMeshPro text;
    public GameObject DmgTextSpawn;
    public float timeBeforeGone = 1f;


    void Update(){
        timeBeforeGone = timeBeforeGone - Time.deltaTime;
        if (timeBeforeGone <= 0) { Destroy(gameObject); }
    }




    public void PrintDmg(){
        Instantiate(DmgTextSpawn, GameObject.Find("ControllableAnt").transform.position, Quaternion.identity);
    }
}
