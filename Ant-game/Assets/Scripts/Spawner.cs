using UnityEngine;
 
public class Spawner : MonoBehaviour
{
    public GameObject Ant;
    public int numberToSpawn;
    public int limit = 20;
    public float rate;
    private float newXPos;
    private float newYPos;
    float spawnTimer;
    public int moveSpeed = 6;
    public Movement[] Ants;
 
    void Start(){
        spawnTimer = rate;
    }
 
    void Update(){
        if (gameObject.transform.childCount < limit){
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f){
                for (int i = 0; i < numberToSpawn; i++){
                    newXPos = this.transform.position.x + GetModifier();
                    newYPos = this.transform.position.y + GetModifier();
                    Instantiate(Ant, new Vector3(newXPos, newYPos)
                        , Quaternion.Euler(0, 0, Random.Range(0f, 360f)), gameObject.transform);
                    SpeedStuff();
                }
                spawnTimer = rate;
            }
        }
    }
 
    float GetModifier(){
        float modifier = 5f;
        if (Random.Range(0, 2) > 0)
            return -modifier;
        else
            return modifier;
    }

    public void SpeedStuff(){
        Ants = GetComponentsInChildren<Movement>();
        foreach(Movement mov in Ants){
            mov.moveSpeed = moveSpeed;
        }
    }
}


//tyvstjålet fra https://thehardestwork.com/2020/12/10/how-to-build-a-spawner-in-unity/ vi skal ændre lidt i det :)