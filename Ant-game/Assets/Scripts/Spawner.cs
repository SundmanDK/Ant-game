using UnityEngine;
 
public class Spawner : MonoBehaviour
{
    public GameObject Ant;
    public GameObject colony;
    public int numberToSpawn;
    public int limit = 20;
    public float rate;
    private float newXPos;
    private float newYPos;
 
    float spawnTimer;
 
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = rate;
    }
 
    // Update is called once per frame
    void Update()
    {
        if (colony.transform.childCount < limit)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                for (int i = 0; i < numberToSpawn; i++)
                {
                    newXPos = this.transform.position.x + GetModifier();
                    newYPos = this.transform.position.y + GetModifier();
                    Instantiate(Ant, new Vector3(newXPos, newYPos)
                        , Quaternion.Euler(0, 0, Random.Range(0f, 360f)), colony.transform);
                }
                spawnTimer = rate;
            }
        }
    }
 
    float GetModifier()
    {
        float modifier = 5f;
        if (Random.Range(0, 2) > 0)
            return -modifier;
        else
            return modifier;
    }
}


//tyvstjålet fra https://thehardestwork.com/2020/12/10/how-to-build-a-spawner-in-unity/ vi skal ændre lidt i det :)