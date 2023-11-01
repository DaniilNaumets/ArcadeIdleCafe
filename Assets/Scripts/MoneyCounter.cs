using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private GameObject _goldCoins;

    [SerializeField] private UIForPlayer _UIPlayer;


    [SerializeField] private int coins;


    public int Coins
    {
        get { return coins; }
        set { coins = value; }
    }

    public void AddMoney(int cash)
    {
        _money += cash;
        if(_money > 20)
        {
            _money = 20;
        }
        CountMoney();
    }

    private void CountMoney()
    {
        if(!_goldCoins.activeSelf && _money != 0)
        {
            _goldCoins.SetActive(true);
            return;
        }
        else
        if(_money == 0)
        {
            _goldCoins.SetActive(false);
            return;
        }
        if(_money != 0)
        {
            _goldCoins.gameObject.transform.localScale = new Vector3(_money, _money, _money);
            return;
        }

    }

    public int GetMoney()
    {
        coins += _money;
        _money = 0;
        _UIPlayer.RefreshMoneyText(coins);
        CountMoney();
        return coins;
    }

}
