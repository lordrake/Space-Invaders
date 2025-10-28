using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{

    public GameObject enemyProjectile;
    public float spawnTimer;
    public float spawnMax = 10;
    public float spawnMin = 5;
    public float spawnProbabily = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        setTimer();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            if (Random.value < spawnProbabily)
            {
                Instantiate(enemyProjectile, transform.position, Quaternion.identity);
            }
        
            setTimer();
        }
    }

    void setTimer()
    {
        spawnTimer = Random.Range(spawnMin, spawnMax);
    }
}
