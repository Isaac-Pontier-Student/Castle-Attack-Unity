using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float force, radius, modifier;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyExplosion", 0.1f);
    }

    private void OnTriggerEnter(Collider other) //Takes in the other collider that is overlapping our trigger collider
    {
        print(other.name + "'s collider just entered the trigger collider");
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        if (rigidbody)
        {
            print(rigidbody.name + " is the rigidbody that is about to get exploderated");
            rigidbody.AddExplosionForce(force, transform.position, radius, modifier, ForceMode.VelocityChange);
        }
    }

    void DestroyExplosion()
    {
        Destroy(gameObject);
    }
}
