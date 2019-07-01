using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //public float Speed;
    //private Transform Target;


    public float enemyLookDistance;
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

        /*target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 direction = target.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 10 * Time.deltaTime);
        transform.position += transform.forward * Speed * Time.deltaTime;*/
    }

    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime + damping);
    }
}
