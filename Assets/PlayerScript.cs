using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Rigidbody player = GetComponent<Rigidbody>();
        player.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
    }
}
