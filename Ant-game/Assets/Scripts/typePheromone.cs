using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typePheromone : MonoBehaviour{
    public float timeBeforeGone = 40f;

    // Update is called once per frame
    void Update(){
        timeBeforeGone = timeBeforeGone - Time.deltaTime;
        if (timeBeforeGone <= 0) { Destroy(gameObject); }
    }

   public void Invisable(){
        this.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Visable(){
        this.GetComponent<SpriteRenderer>().enabled = true;
    }
}
