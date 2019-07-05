using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public int health;

    private HealthControllerScript healthController;

    public bool isInvincible = false;
    public Color playerColor;

    private void Start()
    {
        healthController = GameObject.FindGameObjectWithTag("HealthController").GetComponent<HealthControllerScript>();
        playerColor = GetComponent<Renderer>().material.color;
        StartCoroutine(CoroutineIsteadUpdate());
    }

    IEnumerator CoroutineIsteadUpdate()
    {
        while (true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Rigidbody player = GetComponent<Rigidbody>();
            player.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

            yield return null;
        }
    }

    public void ChangeHealth(int points)
    {
        if (points < 0 && !isInvincible)
            health += points;
        else if (points > 0)
            health += points;

        if (health > 100) health = 100;
        healthController.WriteHealth(health);
    }
}
