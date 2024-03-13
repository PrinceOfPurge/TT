using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.LoseHealth();
        }
    }
}