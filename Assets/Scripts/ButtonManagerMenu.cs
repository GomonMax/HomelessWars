using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManagerMenu : MonoBehaviour
{
    [SerializeField] private GameObject _map;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _upgrate;
    [SerializeField] private GameObject _flags;
    [SerializeField] private UpgradeProperties _upgradeProperties;
    [SerializeField] private Money _money;
    [SerializeField] AnimationManager _animationManager;

    public void OpenMap()
    {
        _upgrate.SetActive(false);
        _menu.SetActive(false);
        _flags.SetActive(true);
        _map.SetActive(true);
        _animationManager.animationNameOpen();
    }
    public void CloseMap()
    {
        _map.SetActive(false);
        _upgrate.SetActive(false);
        _flags.SetActive(false);
        _menu.SetActive(true);
        _animationManager.animationNameClose();
    }
    public void OpenUpgrate()
    {
        _map.SetActive(false);
        _menu.SetActive(false);
        _upgrate.SetActive(true);
    }
    public void CloseUpgrate()
    {
        _map.SetActive(false);
        _upgrate.SetActive(false);
        _menu.SetActive(true);
    }
    public void SpeedUpgrate()
    {
        float money = _money.MoneyUpdate;
        float price = _upgradeProperties.PriceSpeed;
        float speed = _upgradeProperties.SpeedProduction;
        if (money >= price && speed >= 0.1f)
        {
            _money.MoneyUpdate -= price;
            speed -= 0.02f;
            _upgradeProperties.SpeedProduction = speed;
            price *= 1.3f;
            _upgradeProperties.PriceSpeed = price;
        }
    }
    public void HpUpgrate()
    {
        float money = _money.MoneyUpdate;
        float price = _upgradeProperties.PriceHp;
        if (money >= price)
        {
            _money.MoneyUpdate -= price;
            float hp = _upgradeProperties.HpTrash;
            hp += 5f;
            _upgradeProperties.HpTrash = hp;
            price *= 1.3f;
            _upgradeProperties.PriceHp = price;
        }
    }
    public void StartBonusUpgrate()
    {
        float money = _money.MoneyUpdate;
        float price = _upgradeProperties.PriceStart;
        if (money >= price)
        {
            _money.MoneyUpdate -= price;
            float start = _upgradeProperties.StartBonus;
            start += 1f;
            _upgradeProperties.StartBonus = start;
            price *= 1.3f;
            _upgradeProperties.PriceStart = price;
        }
    }
}
