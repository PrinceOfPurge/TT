
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //UI health display
    public Text txt_healthCount;
    //default health value for inialization
    public int defaulthealthCount;
    //Current health count
    public int healthCount;

    //Init health system (resets health)
    public void Init()
    {
        healthCount = defaulthealthCount;
        txt_healthCount.text = healthCount.ToString();
    }
    
    //Lose health
    public void LoseHealth()
    {
        if (healthCount < 1)
            return;
        healthCount--;
        txt_healthCount.text = healthCount.ToString();
        
        CheckHealthCount();
    }

    public void CheckHealthCount()
    {
        if (healthCount<1)
        {
            Debug.Log("You Lose");
            //call reset values and stop game from manager <here>
        }
    }
    
}