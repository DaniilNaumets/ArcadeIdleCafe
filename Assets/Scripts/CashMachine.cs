using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class CashMachine : MonoBehaviour
{
    [SerializeField] private int[] food;
    [SerializeField] private GameObject _foodPrefab;
    [SerializeField] private GameObject[] _positionForFood;
    [SerializeField] private AIEmployee _employee;

    [SerializeField] private int _cashForOnePiece;

    public int CashForOnePiece
    {
        get { return _cashForOnePiece; }
        set { _cashForOnePiece = value; }
    }

    public void StartCashMachine()
    {
        food = new int[_positionForFood.Length];

        for (int i = 0; i < food.Length; i++)
        {
            food[i] = 0;
        }
    }
    public bool AddFood()
    {

        for (int i = 0; i < food.Length; i++)
        {
            if (!_positionForFood[i].activeSelf)
            {
                food[i] = 1;
                _positionForFood[i].SetActive(true);
                break;
            }
            else if(i == _positionForFood.Length - 1)
            {
                return false;
            }
            
        }
        return true;

    }

    public bool GetFood()
    {
        for (int i = food.Length - 1; i >= 0; i--)
        {
            if (_positionForFood[i].activeSelf)
            {
                food[i] = 0;
                _positionForFood[i].SetActive(false);
                if(i == 3)
                {
                    _employee.Agent.speed = 1;
                }
                
                break;
            }
            else if(i == 0)
            {
                return false;
            }
        }
        return true;
    }

    public bool isTableBusy()
    {
        for (int i = 0; i < food.Length; i++)
        {
            if (food[i] == 0)
            {
                return false;
            }
        }
        return true;
    }

    public bool isTableEmpty()
    {
        for (int i = 0; i < food.Length; i++)
        {
            if (food[i] == 1)
            {
                return false;
            }
        }
        return true;
    }


}
