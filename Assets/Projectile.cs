using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float forceAmount = 15.0f;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        Vector3 forceDirection = transform.forward;

        rigidbody.AddForce(forceDirection * forceAmount, ForceMode.VelocityChange);
    }
    //messages are methods in a script that are only called/used if they are defined. EG Update or OnCollisionEnter won't be used if we don't call them
    //start and update are messages sent from unity engine to our scripts too. These are part of the MonoBehavior Lifecycle
    void OnCollisionEnter(Collision other) //OnCollisionEnter is a built-in MonoBehavior method but it only does anything when the scripts define it in their own functions (here)
    {
        //"other" is our instance of the Collision class
        //"gameObject" is the game object that we are colliding with
        if (other.gameObject.CompareTag("Castle"))
        {
            //Instantiate explosion prefab at projectile position
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // Destroy projectile
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
