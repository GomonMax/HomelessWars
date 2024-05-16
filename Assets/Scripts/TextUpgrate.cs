using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUpgrate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textPriceSpeed;
    [SerializeField] private TextMeshProUGUI _textPriceHp;
    [SerializeField] private TextMeshProUGUI _textPriceStart;

    [SerializeField] private TextMeshProUGUI _textCurrentSpeed;
    [SerializeField] private TextMeshProUGUI _textCurrentHp;
    [SerializeField] private TextMeshProUGUI _textCurrentStart;

    [SerializeField] private UpgradeProperties _upgradeProperties;

    private void Start()
    {
        ChangeText();
    }

    public void ChangeText()
    {
        _textPriceSpeed.text = _upgradeProperties.PriceSpeed.ToString();
        _textPriceHp.text = _upgradeProperties.PriceHp.ToString();
        _textPriceStart.text = _upgradeProperties.PriceStart.ToString();

        _textCurrentSpeed.text = _upgradeProperties.SpeedProduction.ToString();
        _textCurrentHp.text = _upgradeProperties.HpTrash.ToString();
        _textCurrentStart.text = _upgradeProperties.StartBonus.ToString();
    }

}
