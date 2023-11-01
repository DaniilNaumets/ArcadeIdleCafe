using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _cameraSpeed;


    private void FixedUpdate()
    {
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        Vector3 cameraPosition = _player.position + _offset;
        transform.position = Vector3.Lerp(transform.position, cameraPosition, _cameraSpeed * Time.deltaTime);
    }
}
