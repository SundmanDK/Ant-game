using UnityEngine;
using System.Collections;

public class pheromoneControlableAnt : MonoBehaviour
{
    public float timeToThink = 2.0f;
    public float timer = 0.0f;
    private ControlableAnt move;
    public Transform redPheromone;
    public Transform bluePheromone;
    public GameObject pheromoneGroupe;

    void Start(){
        move = GetComponent<ControlableAnt>();
    }

    void FixedUpdate(){
        timer += Time.deltaTime;
        if (move.holdingFood == true) {
            if (timer > timeToThink){
                Instantiate(redPheromone, transform.position, Quaternion.identity, pheromoneGroupe.transform);
                timer = timer - timeToThink;
            }
        }else{
            if (timer > timeToThink){
                Instantiate(bluePheromone, transform.position, Quaternion.identity, pheromoneGroupe.transform);
                timer = timer - timeToThink;
            }
        }
       
    }
}