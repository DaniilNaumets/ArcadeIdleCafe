using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSerial : MonoBehaviour
{
    [SerializeField] private MoneyCounter _moneyCounter;
    [SerializeField] private UpgradeMenu _upgradeMenu;
    [SerializeField] private Tutorial _tutorial;

    [SerializeField] private GameObject _saveText;



    SaveData data = new SaveData();

    public void StartLoading()
    {
        if (_upgradeMenu != null && _moneyCounter != null)
            LoadGame();
        Debug.Log(data.IsTutorialHasBeen);
    }
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        if (!File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            file = File.Create(Application.persistentDataPath + "/MySaveData.dat");
        }
        else
        {
            file = File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
        }
        data.Coin = _moneyCounter.Coins;
        data.Upgrade = _upgradeMenu.Upgrades;
        data.IsTutorialHasBeen = _tutorial.IsTutorial;
        bf.Serialize(file, data);
        file.Close();

        Anim();
    }

    

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);

            data = (SaveData)bf.Deserialize(file);
            file.Close();
            _moneyCounter.Coins = data.Coin;
            _upgradeMenu.Upgrades = data.Upgrade;
            _tutorial.IsTutorial = data.IsTutorialHasBeen;
            _upgradeMenu.CheckUpgrades();

        }
    }

    public void ResetData()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath
              + "/MySaveData.dat");
            data.Coin = 0;
            data.Upgrade = null;
            data.IsTutorialHasBeen = false;

        }


    }

    private void Anim()
    {
        _saveText.SetActive(false);
        _saveText.SetActive(true);
    }
}

[Serializable]
class SaveData
{
    public int Coin;
    public bool[] Upgrade;
    public bool IsTutorialHasBeen;

}