using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : AbstractEnemy
{
    public GameObject shot;
    public float shotDelay;

    private float nextShot;

    protected override void Attack()
    {
        if (Time.time > nextShot)
        {
            nextShot = Time.time + shotDelay;
            Instantiate(shot, transform.Find("ImagineGun").gameObject.transform.position, transform.rotation);
        }
    }
}
