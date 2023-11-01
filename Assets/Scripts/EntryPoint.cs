using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private SaveSerial _saveSerial;
    [SerializeField] private CashMachine _cashMachine;
    [SerializeField] private GuestInstaniate _guestInstaniate;
    [SerializeField] private UICashMachine _uiCashMachine;
    [SerializeField] private PlacesInCafe _placesInCafe;
    [SerializeField] private UIForPlayer _uiForPlayer;
    [SerializeField] private MoneyCounter _moneyCounter;

    private void Awake()
    {
        _saveSerial.StartLoading();
        _cashMachine.StartCashMachine();
        _guestInstaniate.StartGuestInstaniate();
        _uiCashMachine.StartUICashMachine();
        _placesInCafe.StartPlacesInCafe();
        _uiForPlayer.RefreshMoneyText(_moneyCounter.Coins);
    }
}