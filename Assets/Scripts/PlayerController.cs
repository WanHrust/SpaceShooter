using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour
{
    public float tilt;
    public Boundary boundary;
    public float speed;
    Rigidbody rigidBody;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

    }

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    public float nextFire;
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject shotClone = GameObject.Instantiate(shot, shotSpawn.position, shotSpawn.rotation); // as GameObject;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidBody.AddForce(movement * speed);
        // rigidBody.MovePosition()
        rigidBody.position = new Vector3
            (
            Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
            rigidBody.position.y,
             Mathf.Clamp(rigidBody.position.z, boundary.zMin, boundary.zMax)
            );
        rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidBody.velocity.x * -tilt);
    }
}

