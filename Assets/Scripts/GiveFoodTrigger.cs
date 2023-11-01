using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveFoodTrigger : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private float timerEnd; 

    private bool isOnPlate;

    [SerializeField] private PlayerFoodGiver _playerFoodGiver;
    [SerializeField] private UIForPlayer _uiForPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOnPlate = true;
            _uiForPlayer.ActiveButton(isOnPlate);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOnPlate = false;
            _uiForPlayer.ActiveButton(isOnPlate);
        }
    }

    private void Update()
    {
        Timer();        
    }

    private void Timer()
    {
        if (timer < timerEnd)
            timer += Time.deltaTime;
        else
        {
            if (!_uiForPlayer.Button.IsInteractable())
            {
                timer = 0.0f;
            }
        }

        if (timer >= timerEnd && isOnPlate)
        {
            _playerFoodGiver.OnPlate = true;
            _uiForPlayer.Button.interactable = true;

        }
    }
}
