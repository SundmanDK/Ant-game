using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typeBluePheromone : MonoBehaviour
{

    public float timeBeforeGone = 20f;


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
}
