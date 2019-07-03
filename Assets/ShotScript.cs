using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public float speed;

    void Start()
    {
        Rigidbody shot = GetComponent<Rigidbody>();
        shot.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.tag != "Player" && other.tag != "Enemy") Destroy(gameObject);
        //Мне не нравятся строки ниже, но пускай пока побудет так
        else if (other.tag == "Player")
        {
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().LoseHealth();
        }
    }
}
