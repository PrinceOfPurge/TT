using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void OnCollisionEnter(Collision collision)
    {
        
        PlayerHealth playerHealth = GetComponent<PlayerHealth>();

        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.LoseHealth();

        }
        
    }
}