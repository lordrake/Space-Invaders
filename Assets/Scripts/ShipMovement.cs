using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float moveSpeed;
    public float yOffset = 1;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - yOffset, transform.position.z);
            moveSpeed = moveSpeed * -1;
        }
    }
}
