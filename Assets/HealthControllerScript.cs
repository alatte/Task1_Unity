using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControllerScript : MonoBehaviour
{
    public GameObject healthText;

    public void WriteHealth(int health)
    {
        healthText.GetComponent<UnityEngine.UI.Text>().text = "Health:" + health;
    }
}
