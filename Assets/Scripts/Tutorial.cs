using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] _tutorialPanels;
    [SerializeField] private GameObject _tutorialMenu;
    [SerializeField] private SaveSerial _saveData;

    [SerializeField] private bool isTutorial;

    public bool IsTutorial
    {
        get { return isTutorial; }
        set { isTutorial = value; }
    }

    private void Start()
    {
        if (!isTutorial)
        {
            _tutorialMenu.SetActive(true);
        }
    }

    public void ChoosePanel(bool isForward)
    {
        int index = 0;

        for (int i = 0; i < _tutorialPanels.Length; i++)
        {
            if (_tutorialPanels[i].activeSelf)
            {
                index = i;
                break;
            }
        }
        if (isForward)
        {
            if (index + 1 != _tutorialPanels.Length)
            {
                _tutorialPanels[index].SetActive(false);
                index++;
                _tutorialPanels[index].SetActive(true);
            }
            else
            {
                _tutorialMenu.SetActive(false);
                isTutorial = true;
                _saveData.SaveGame();
            }
        }
        else
        {
            if (index - 1 != -1)
            {
                _tutorialPanels[index].SetActive(false);
                index--;
                _tutorialPanels[index].SetActive(true);
            }
        }
    }

    public void ActiveMenu(bool isActive)
    {
        _tutorialMenu.SetActive(isActive);
    }

    public void StartTutorial()
    {
        if (!isTutorial)
        {
            _tutorialMenu.SetActive(true);
        }
    }

    
}
