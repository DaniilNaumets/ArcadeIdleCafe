using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFoodGiver : MonoBehaviour
{
    [SerializeField] private CashMachine _cashMachine;
    [SerializeField] private Image _image;

    [SerializeField] private float time;


    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private UIForPlayer UIForPlayer;

    private bool onPlate;

    public bool OnPlate
    {
        get { return onPlate; }
        set { onPlate = value; }
    }

    public void GiveFood()
    {
        if (onPlate)
        {
            UIForPlayer.Button.interactable = false;
            StartCoroutine(Coroutines.FillIcon(_image, 1 / time));
            StartCoroutine(Coroutines.PlayerGiveFood(time, _cashMachine, playerMovement));
            onPlate = false;
        }
    }
}
