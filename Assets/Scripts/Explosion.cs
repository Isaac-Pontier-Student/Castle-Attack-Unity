using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float force, radius, modifier;
    public GameObject explosionFX;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyExplosion", 0.1f);
        Instantiate(explosionFX, transform.position, Quaternion.identity); //destroy later?
    }

    private void OnTriggerEnter(Collider other) //Takes in the other collider that is overlapping our trigger collider
    {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        if (rigidbody)
        {
            rigidbody.AddExplosionForce(force, transform.position, radius, modifier, ForceMode.VelocityChange);
        }
    }

    void DestroyExplosion()
    {
        Destroy(gameObject);
    }
}
