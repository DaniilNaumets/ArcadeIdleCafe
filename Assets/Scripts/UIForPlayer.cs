using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIForPlayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private GameObject _gbButton;

    [SerializeField] private Button _button;

    [SerializeField] private GameObject _upgradeMenu;
    public Button Button
    {
        get { return _button; }
        set { _button = value; }
    }

    int cash;


    public void ConvertMoneyToText(int money)
    {
        cash += money;
        _moneyText.text = $"{cash} $";
    }

    public void ActiveButton(bool isTrue)
    {
        if (isTrue)
        {
            _gbButton.SetActive(true);
        }
        else
        {
            _gbButton.SetActive(false);
        }
    }

    public void OpenUpgradeMenu()
    {
        if (!_upgradeMenu.activeSelf)
        {
            _upgradeMenu.SetActive(true);
        }
        else
        {
            _upgradeMenu.SetActive(false);
        }
    }

    public void RefreshMoneyText(int money)
    {
        _moneyText.text = $"{money} $";
    }
}
