using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
[System.Serializable]
public class Boundary {
    public float xMin, xMax, zMin, zMax;
}
*/
public class PlayerMultipleController : MonoBehaviour {
    public string horizontalAxis = "Horizontal";
    public string vertixalAxis = "Vertical";
    public float tilt;
    public Boundary boundary;
    public float speed;
    Rigidbody rigidBody;
    private void Start() {
        rigidBody = GetComponent<Rigidbody>();

    }
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis(horizontalAxis);
        float moveVertical = Input.GetAxis(vertixalAxis);

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

