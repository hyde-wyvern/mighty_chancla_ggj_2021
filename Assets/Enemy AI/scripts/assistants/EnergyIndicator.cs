using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnergyIndicator : MonoBehaviour
{
    [SerializeField]
    private EnergySystem energySystem;

    public TMP_Text label;
    public GameObject chargingIcon;
    public GameObject percentageIcon;
    public Image percentageAmount;


    // Update is called once per frame
    void Update()
    {
        percentageAmount.fillAmount = energySystem.currentEnergy / 100;
        label.text = energySystem.currentEnergy.ToString() + "%";
        switch (energySystem.state)
        {
            case EnergyState.Charging:
                chargingIcon.SetActive(true);
                percentageIcon.SetActive(false);
                break;
            case EnergyState.Consuming:
                chargingIcon.SetActive(false);
                percentageIcon.SetActive(true);
                break;
            case EnergyState.Dashing:
                chargingIcon.SetActive(false);
                percentageIcon.SetActive(true);
                break;
        }
    }
}