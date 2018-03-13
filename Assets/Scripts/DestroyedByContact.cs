using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedByContact : MonoBehaviour
{
    public GameObject playerExplosion;
    public GameObject explosion;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(playerExplosion, transform.position, transform.rotation); // as GameObject;
        if (other.tag == "player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation); // as GameObject;
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }



}
