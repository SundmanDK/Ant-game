using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestStorage : MonoBehaviour{
    public int food;
    public int score;
    public int gold;

    // Start is called before the first frame update
    void Start() {
        food  = 0;
        score = 0;
        gold  = 0;


        Debug.Log(food);

    }
}
