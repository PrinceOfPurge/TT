using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackMode : MonoBehaviour
{
    
    private void switchAttack()
    {
        PlayerHealth playerHealth = GetComponent<PlayerHealth>();

        if (playerHealth.healthCount <= 0)
        {
            switchAttack();
                
            Debug.Log("Player has switched to attack");
        }
    }
}
