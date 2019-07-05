using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, Time.deltaTime * 20, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") Destroy(gameObject);
    }
}
