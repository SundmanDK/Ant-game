using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class SpawnDmgText : MonoBehaviour
{
    
    public GameObject DmgTextSpawn;
    public float timeBeforeGone = 1f;
  
   
    
    void Start()
    {
       
    }
    void Update()
    {
        timeBeforeGone = timeBeforeGone - Time.deltaTime;
        if (timeBeforeGone <= 0) { Destroy(gameObject); }
    }

    //GameObject.Find("ControllableAnt").transform.position


    public void PrintDmg()
    {
        
        Instantiate(DmgTextSpawn, GameObject.Find("ControllableAnt").transform.position+ new Vector3(Random.Range(-20, 20), Random.Range(-20,20), 0), Quaternion.identity);
      
    }

}
