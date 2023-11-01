using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AIGuest : MonoBehaviour
{
    public event System.Action<float> FillSpeedChange;


    [SerializeField] internal CashMachine _cashMachine;
    [SerializeField] internal PlacesInCafe places;
    [SerializeField] private UICashMachine _manager;

    private Animator agentAnimator;
    private NavMeshAgent agent;

    [SerializeField] private float _timeForPrepare;


    private bool isGet;
    private bool isToEnd;
    [SerializeField] GameObject target;


    MoneyCounter moneyCounter;

#region Start
    private void Start()
    {
        places = FindObjectOfType<PlacesInCafe>();
        _manager = FindObjectOfType<UICashMachine>();
        agentAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target = places.GetPlace();
        _cashMachine = places.GetCashMachine(target);
        agent.destination = target.transform.position;
        agent.updateRotation = true;
        isGet = false;
        isToEnd = false;
        moneyCounter = places.GetMoneyCounter();
    }
    #endregion

    private void Update()
    {
        GuestMovement();
    }

    public void SetFillSpeed(float newFillSpeed)
    {
        FillSpeedChange?.Invoke(newFillSpeed);
    }

    public void GuestMovement()
    {
        if (agent.remainingDistance <= agent.stoppingDistance && this._cashMachine.isTableEmpty() && !isGet)
        {
            agent.speed = 0;

        }
        else if (agent.remainingDistance <= agent.stoppingDistance && !isGet)
        {

            places.FreePlace(target);
            StartCoroutine(Coroutines.MovingForGuestToPay(_timeForPrepare, places.GetPlaceForPay(), this.agent, this));
            isGet = true;

        }

        if (agent.remainingDistance <= agent.stoppingDistance && agent.speed != 0 && isGet && !isToEnd)
        {
            StartCoroutine(Coroutines.MovingForGuestToEnd(_timeForPrepare, places.GetEnd(), this.agent, this, moneyCounter, _cashMachine.CashForOnePiece));
            isToEnd = true;
        }


        agentAnimator.SetFloat("speed", agent.speed);
    }

    
}
