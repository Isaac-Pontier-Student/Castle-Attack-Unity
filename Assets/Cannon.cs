using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Animator animator;
    public Transform fireSocket;
    public float rotationRate = 90.0f;
    public ParticleSystem fireFX;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float aimInput = Input.GetAxis("Horizontal");
        aimInput *= rotationRate * Time.deltaTime;
        transform.Rotate(Vector3.right * aimInput, Space.World);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void Fire()
    {
        animator.SetTrigger("Fire"); //sets the animation fire trigger to true. The state machine will register that, run the Fire animation, then reset this trigger to false.
        Instantiate(projectilePrefab, fireSocket.position, fireSocket.rotation);
        fireFX.Play();
    }
}
