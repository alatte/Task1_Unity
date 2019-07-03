using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour
{
    public float enemyLookDistance;
    public float speed;
    public float damping;
    public float rayDistance;

    private float targetDistance;
    protected GameObject target;

    protected abstract void Attack();

    void Update()
    {
        targetDistance = Vector3.Distance(target.transform.position, transform.position);
        if (targetDistance < enemyLookDistance)
        {
            GoToPlayer();
        }
    }

    void GoToPlayer()
    {
        Vector3 rotation = (target.transform.position - transform.position).normalized;
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.green);

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
        {
            if (hit.collider.gameObject.tag == "Obstacle")
            {
                rotation += hit.normal * 30;
            }
            else if (hit.collider.gameObject.tag == "Player")
            {
                Attack();
            }
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotation), Time.deltaTime * damping);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
}

