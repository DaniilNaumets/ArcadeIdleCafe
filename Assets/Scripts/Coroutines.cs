using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Coroutines : MonoBehaviour
{
    public static IEnumerator MoveToNewDestination(float timeBeforeGoing, GameObject newDestination, NavMeshAgent agent)
    {
        agent.speed = 0;
        yield return new WaitForSeconds(timeBeforeGoing);
        agent.SetDestination(newDestination.transform.position);
        agent.speed = 1;
    }

    public static IEnumerator PlayerGiveFood(float time, CashMachine cashMachine, PlayerMovement player)
    {
        float speed = player.Speed;
        player.Speed = 0;
        player.InMovement = false;
        yield return new WaitForSeconds(time);
        cashMachine.AddFood();
        player.Speed = speed;
        player.InMovement = true;
    }

    public static IEnumerator MovingForGuestToPay(float timeBeforeGoing, GameObject newDestination, NavMeshAgent agent, AIGuest guest)
    {
        agent.speed = 0;
        guest._cashMachine.GetFood();
        yield return new WaitForSeconds(timeBeforeGoing);
        agent.SetDestination(newDestination.transform.position);
        agent.speed = 1;
    }

    public static IEnumerator MovingForGuestToEnd(float timeBeforeGoing, GameObject endDestination, NavMeshAgent agent, AIGuest guest, MoneyCounter moneyCounter, int cashForOnePiece)
    {
        agent.speed = 0;
        yield return new WaitForSeconds(timeBeforeGoing);
        moneyCounter.AddMoney(cashForOnePiece);
        agent.SetDestination(endDestination.transform.position);
        agent.speed = 1;
    }
    public static IEnumerator CashierGetMoney(float time, MoneyCounter moneyCounter)
    {
        yield return new WaitForSeconds(time);
        moneyCounter.GetMoney();
    }

    public static IEnumerator InstaniateGuest(int count, GameObject prefab, Vector3 position, int time)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(prefab, position, Quaternion.identity);
            yield return new WaitForSeconds(time);
        }


    }

    public static IEnumerator FillIcon(Image image, float fillSpeed)
    {
        float fillAmount = image.fillAmount;
        while (fillAmount < 1f)
        {
            fillAmount += fillSpeed * Time.deltaTime;
            fillAmount = Mathf.Clamp01(fillAmount);
            image.fillAmount = fillAmount;
            if (fillAmount == 1f)
            {
                image.fillAmount = 0;
            }
            yield return null;
        }
    }
}
