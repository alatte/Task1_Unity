using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : AbstractEnemy
{
    void OnCollisionEnter(Collision collisionObject)
    {
        if (collisionObject.gameObject.tag == "Player")
        {
            target.GetComponent<PlayerScript>().LoseHealth();
        }
    }

    protected override void Attack() { }
}
