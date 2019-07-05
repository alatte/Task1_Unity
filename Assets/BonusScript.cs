using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BonusScript : MonoBehaviour
{
    protected GameObject target;
    
    public void SetTarget (GameObject target)
    {
        this.target = target;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            StartCoroutine(BufTarget());
        }
    }

    protected abstract IEnumerator BufTarget();
}
