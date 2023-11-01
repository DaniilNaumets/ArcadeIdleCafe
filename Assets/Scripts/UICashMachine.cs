using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UICashMachine : MonoBehaviour
{
    [SerializeField] AIEmployee _AIEmployee;
    [SerializeField] Image _iconProccesImage;

    [SerializeField] private float fillSpeed;

    #region
    private bool isNearTable;

    public bool IsNearTable
    {
        get { return isNearTable; }
        set { isNearTable = value; }
    }

    private bool isNearSecondTable;

    public bool IsNearSecondTable
    {
        get { return isNearSecondTable; }
        set { isNearSecondTable = value; }
    }
    #endregion


    private void Update()
    {
        FillImage();
    }

    public void StartUICashMachine()
    {
        IsNearTable = false;
        _AIEmployee.FillSpeedChange += UpdateFillSpeed;
    }

    public bool FillIconImage(float fillSpeed, bool isNearTable)
    {
        if (isNearTable)
        {
            _iconProccesImage.fillAmount += fillSpeed * Time.deltaTime;

            if (_iconProccesImage.fillAmount == 1)
            {
                IsNearTable = false;
                _iconProccesImage.fillAmount = 0;
                return false;
            }

        }
        return true;
    }

    private void UpdateFillSpeed(float newFillSpeed)
    {
        fillSpeed = newFillSpeed;
    }

    private void FillImage()
    {
        if (!FillIconImage(fillSpeed, IsNearTable))
        {

            if (!_AIEmployee.AddFoodOnTable())
            {
                _iconProccesImage.color = Color.red;
            }
            else
            {
                _iconProccesImage.color = new Color(0f, 1f, 0f);
            }
        }
    }
}
