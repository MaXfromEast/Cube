using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cubes")
        {
            Destroy(other.gameObject);
            Debug.Log("ping");
        }
    }
}
