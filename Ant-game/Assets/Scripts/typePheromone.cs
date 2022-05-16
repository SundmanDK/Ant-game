using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typePheromone : MonoBehaviour{
    public float timeBeforeGone = 40f;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        timeBeforeGone = timeBeforeGone - Time.deltaTime;
        if (timeBeforeGone <= 0) { Destroy(gameObject); }
    }


   public void Invisable()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log("Who call1");
    }

    public void Visable()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
        Debug.Log("Who cal22");
    }
}
