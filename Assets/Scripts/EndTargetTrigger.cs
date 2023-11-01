using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTargetTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Guest")){
            Destroy(other.gameObject);
        }
    }
}
