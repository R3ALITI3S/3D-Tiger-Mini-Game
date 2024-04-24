using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private float counter = 0;
    private float spawnTime = 8; // time of which the enemies should spawn<
    public GameObject enemyPrefab;
    public Transform spawnPoint; // the object from where they should spawn.
    public int TotalEnemies = 5; // how many to spawn
    public int SpawnCounter = 0; //How many it has spawned

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (SpawnCounter < TotalEnemies && counter > spawnTime)
        {
            counter = 0;
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation); 
            SpawnCounter++;
        }
    }   
}