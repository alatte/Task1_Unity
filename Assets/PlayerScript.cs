using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public int health;

    private HealthControllerScript healthController;
    private void Start()
    {
        healthController = GameObject.FindGameObjectWithTag("HealthController").GetComponent<HealthControllerScript>();
        StartCoroutine(CoroutineIsteadUpdate());
    }

    /*void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Rigidbody player = GetComponent<Rigidbody>();
        player.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
    }*/

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

    public void LoseHealth()
    {
        healthController.WriteHealth(--health);
    }
}
