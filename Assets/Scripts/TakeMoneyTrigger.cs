using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TakeMoneyTrigger : MonoBehaviour
{
    [SerializeField] private MoneyCounter _moneyCounter;
    [SerializeField] private bool _isCashierHere;

    public bool IsCashierHere
    {
        get { return _isCashierHere; }
        set { _isCashierHere = value; }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !_isCashierHere)
        {
            _moneyCounter.GetMoney();
        }
        if(other.gameObject.CompareTag("Guest") && _isCashierHere)
        {
            StartCoroutine(Coroutines.CashierGetMoney(2f,_moneyCounter));
        }

        
    }
}
