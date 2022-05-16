using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homeCall : MonoBehaviour
{
    private SpiderStuff[] enemies;
    private void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.layer == 13){
            enemies = GetComponentsInChildren<SpiderStuff>();
            enemies[0].inArea = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.layer == 13){
            enemies = GetComponentsInChildren<SpiderStuff>();
            enemies[0].inArea = true;
        }
    }
}
