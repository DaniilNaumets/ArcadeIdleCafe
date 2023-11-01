using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GuestInstaniate : MonoBehaviour
{
    [SerializeField] GameObject _guestPrefab;
    [SerializeField] GameObject[] _positionsForInstiniateGuests;

    System.Random random;

    [SerializeField] private float spawnInterval;

    public float SpawnInterval
    {
        get { return spawnInterval; }
        set { spawnInterval = value; }
    }

    [SerializeField] private float timer;

    public void StartGuestInstaniate()
    {
        random = new System.Random();
        Instantiate(_guestPrefab, GetRandomPosition(), Quaternion.identity);
    }

    private void Update()
    {
        TimerToInstiniate();
    }

    private Vector3 GetRandomPosition()
    {
        return _positionsForInstiniateGuests[random.Next(_positionsForInstiniateGuests.Length)].transform.position;
    }

    public void ChangeSpawnInterval(float newSpawnInterval)
    {
        spawnInterval = newSpawnInterval;
    }

    public void TimerToInstiniate()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            Instantiate(_guestPrefab, GetRandomPosition(), Quaternion.identity);
            timer = 0.0f;
        }
    }


}
