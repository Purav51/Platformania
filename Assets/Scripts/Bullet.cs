using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D myRB;
    [SerializeField] float bulletSpeed = 10f; 
    PlayerMovement player;
    float xSpeed;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        myRB.linearVelocity = new Vector2(xSpeed, 0f);   
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject, 0.03f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 0.64f);
    }
}
