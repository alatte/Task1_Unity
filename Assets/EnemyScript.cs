using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float enemyLookDistance;
    public float attackDistance;
    public float speed;
    public float damping;

    Transform target;
    Rigidbody rigidbody;
    float targetDistance;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        targetDistance = Vector3.Distance(target.position, transform.position);
        if (targetDistance < enemyLookDistance)
        {
            lookAtPlayer();
        }

        if (targetDistance < attackDistance)
        {
            attackPlease();
        }
    }

    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime*damping);
    }

    void attackPlease()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
