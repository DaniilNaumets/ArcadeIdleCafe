using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private void Update()
    {
        LookAtPlayer();
    }

    public void LookAtPlayer()
    {
        if (mainCamera != null)
        {
            Vector3 direction = mainCamera.transform.position - transform.position;

            transform.LookAt(transform.position + direction);
        }
    }
}
