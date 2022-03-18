using UnityEngine;
using System.Collections;

public class pheromoneInstantiat : MonoBehaviour
{
    public float timeToThink = 2.0f;
    public float timer = 0.0f;
    public float weight = 1;

    public Transform prefab;
    void Start()
    {
        
    }



    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeToThink)
        {

            Instantiate(prefab, transform.position, Quaternion.identity);
            timer = timer - timeToThink;
            //Debug.Log();
        }
    }
}