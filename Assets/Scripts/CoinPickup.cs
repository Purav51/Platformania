using Unity.VisualScripting;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinpickupSFX;
    [SerializeField] int pointsForCoinPickup = 100;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(coinpickupSFX, transform.position);
            FindFirstObjectByType<GameSession>().AddToScore(pointsForCoinPickup);
            Destroy(gameObject);
        }
    }
}
