using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
    public GameObject explostionPrefab;
    private PointManager pointManager;
    private int pointIncrement = 50;
    private GameObject[] listOfEnemies;

    public PlayerLives playerLives;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
        playerLives = GameObject.Find("PlayerShip").GetComponent<PlayerLives>();

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(explostionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            pointManager.UpdateScore(pointIncrement);
            checkIfVictory();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }


    }
    
    private void checkIfVictory()
    {
        listOfEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(listOfEnemies.Length);

        if (listOfEnemies.Length <= 1)
        {
            playerLives.ShowGameOver();
        }
    }
}
