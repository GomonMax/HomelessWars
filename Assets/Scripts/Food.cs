using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Food : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _currentFoodText;
    [SerializeField] private UpgradeProperties _upgradeProperties;

    public float _currentFood;
    [SerializeField] private float timer;
    [SerializeField] private float interval;

    private void Start()
    {
        _slider.maxValue = _upgradeProperties.SpeedProduction;
        _currentFood = _upgradeProperties.StartBonus;
        interval = _slider.maxValue;
    }

    private void Update()
    {
        ChangeSlider();
        ChangeText();
    }

    private void ChangeSlider()
    {
        _slider.value = timer;
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            _currentFood++;
            timer = 0;
        }
    }
    private void ChangeText()
    {
        _currentFoodText.text = _currentFood.ToString();
    }
}
