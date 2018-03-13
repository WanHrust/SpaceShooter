using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomrotatour : MonoBehaviour
{


    public float tumble;
    Rigidbody rigidBody;
    private void Start()
    {




        rigidBody = GetComponent<Rigidbody>();

        rigidBody.angularVelocity = Random.insideUnitSphere * tumble;



    }
}


