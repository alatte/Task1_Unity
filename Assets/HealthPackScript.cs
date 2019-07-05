using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackScript : BonusScript
{
    public int healthPoints;

    protected override IEnumerator BufTarget()
    {
        target.GetComponent<PlayerScript>().ChangeHealth(healthPoints);
        yield return null;
    }
}
