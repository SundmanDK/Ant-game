using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class SpawnDmgText : MonoBehaviour
{
    public TextMeshPro text;
    public GameObject DmgTextSpawn;
 
    public void PrintDmg()
    {
        Instantiate(DmgTextSpawn, GameObject.Find("ControllableAnt").transform.position, Quaternion.identity);
        
    }
}
