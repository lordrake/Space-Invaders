using UnityEngine;
using UnityEngine.UI;
public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public Image[] livesUI;
    public GameObject explosionPrefab;
    public GameObject gameOverPanel;

    public PointManager pointManager;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            decreaseLives(1);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            Destroy(collision.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            decreaseLives(1);
        }
    }
    
    void decreaseLives(int amount)
    {
            lives -= amount;

            for (int i = 0; i < livesUI.Length; i++)
            {
                if (i < lives)
                {
                    livesUI[i].enabled = true;
                }
                else
                {
                    livesUI[i].enabled = false;
                }
            }

            if (lives <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;
                pointManager.HighScoreUpdate();
                gameOverPanel.SetActive(true);
            }
    }
}
