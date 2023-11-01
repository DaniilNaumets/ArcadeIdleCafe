using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Apple;

public class AIEmployee : MonoBehaviour
{
    public event System.Action<float> FillSpeedChange;

    [SerializeField] internal CashMachine _cashMachine;
    [SerializeField] private UICashMachine _manager;
    [SerializeField] private Animator _agentAnimator;

    private NavMeshAgent _agent;

    public NavMeshAgent Agent
    {
        get { return _agent; }
        set { _agent = value; }
    }


    [SerializeField] private GameObject[] _targets;
    [SerializeField] private GameObject[] _targetsToRotate;

    private int index;

    [SerializeField] private float _timeForPrepare;

    public float TimeForPrepare
    {
        get { return _timeForPrepare; }
        set { _timeForPrepare = value; }
    }



    [SerializeField] private int numEmployee;

    private void Start()
    {
        index = 0;
        _agentAnimator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _agent.destination = _targets[index].transform.position;
        _agent.updateRotation = true;

    }

    private void Update()
    {
        EmployeeMovement();
    }

    public void SetFillSpeed(float newFillSpeed)
    {
        FillSpeedChange?.Invoke(newFillSpeed);
    }

    public bool AddFoodOnTable()
    {
        if (!this._cashMachine.AddFood())
        {
            this._agent.speed = 0;
            return false;
        }
        return true;
    }

    public void EmployeeMovement()
    {
        if (this._cashMachine.isTableBusy())
        {
            _agent.speed = 0;
        }
        else
        {

            if (_agent.remainingDistance <= _agent.stoppingDistance && _agent.speed != 0 )
            {


                SetFillSpeed(1 / _timeForPrepare);
                StartCoroutine(Coroutines.MoveToNewDestination(_timeForPrepare, _targets[index], this._agent));

                index++;

                if (index == _targets.Length)
                {
                    index = 0;
                }

                if (index == 1)
                {
                    switch (numEmployee)
                    {
                        case 1: _manager.IsNearTable = true; break;
                        case 2: _manager.IsNearSecondTable = true; break;


                    }

                }

            }

        }

        _agentAnimator.SetFloat("speed", _agent.speed);
    }


}
