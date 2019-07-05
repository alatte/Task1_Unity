using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : BonusScript
{
    public int timeInvivncible;

    protected override IEnumerator BufTarget()
    {
        target.GetComponent<PlayerScript>().isInvincible = true;
        target.GetComponent<Renderer>().material.color = Color.cyan;

        //В общем, оно не работает :(
        yield return new WaitForSeconds(5);
        Debug.Log("Work, please...");
        target.GetComponent<PlayerScript>().isInvincible = false;
        target.GetComponent<Renderer>().material.color = target.GetComponent<PlayerScript>().playerColor;
    }

}
