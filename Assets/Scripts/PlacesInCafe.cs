using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class PlacesInCafe : MonoBehaviour
{
    [SerializeField] private MoneyCounter moneyCounter;


    [SerializeField] internal CashMachine mainCashMachine;
    [SerializeField] internal CashMachine secondCashMachine;


    [SerializeField] List<GameObject> cashOne;
    List<GameObject> cashTwo;

    [SerializeField] GameObject[] _placesForGettingFood;
    [SerializeField] GameObject[] _placesForGettingFoodNew;
    [SerializeField] GameObject[] _placesForPay;
    [SerializeField] GameObject[] _placesForPayNew;



    [SerializeField] GameObject _endTarget;

    private System.Random random;

    public void StartPlacesInCafe()
    {
        random = new System.Random();
    }
    public GameObject GetPlace()
    {

        for (int i = 0; i < _placesForGettingFood.Length; i++)
        {
            if (!cashOne.Contains(_placesForGettingFood[i]))
            {
                cashOne.Add(_placesForGettingFood[i]);
                return _placesForGettingFood[i];
            }
        }

        return _endTarget;
    }

    public GameObject GetPlaceForPay()
    {
        int numPlace;

        numPlace = random.Next(0, _placesForPay.Length);
        return _placesForPay[numPlace];
    }

    public CashMachine GetCashMachine(GameObject gb)
    {
        if (_placesForGettingFood.Contains(gb))
        {
            return mainCashMachine;
        }
        else if(_placesForGettingFoodNew.Contains(gb))
        {
            return secondCashMachine;
        }
        else if (gb == _endTarget)
        {
            return mainCashMachine;
        }
        return mainCashMachine;
    }

    public void BusyPlace(GameObject gb)
    {
        if (_placesForGettingFood.Contains(gb))
        {
            cashOne.Add(gb);
        }
        else if(_placesForGettingFoodNew.Contains(gb))
        {
            cashTwo.Add(gb);
        }
    }

    public void FreePlace(GameObject gb)
    {
        
        if (cashOne.Contains(gb))
        {
            cashOne.Remove(gb);
        }

    }

    public GameObject GetEnd()
    {
        return _endTarget;
    }

    public MoneyCounter GetMoneyCounter()
    {
        return moneyCounter;
    }
}
