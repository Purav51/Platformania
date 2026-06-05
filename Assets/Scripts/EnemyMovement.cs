using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D GooberRB;
    [SerializeField] float MoveSpeed = 1f;
    void Start()
    {
        GooberRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GooberRB.linearVelocity = new Vector2(MoveSpeed, 0f);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        MoveSpeed = -MoveSpeed;
        FlipEnemySprite();
    }
    void FlipEnemySprite()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(GooberRB.linearVelocity.x)), 1f);
    }
}
