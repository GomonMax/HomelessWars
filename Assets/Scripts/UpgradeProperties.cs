using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeProperties : MonoBehaviour
{
    [SerializeField] private float _speedProduction;
    [SerializeField] private float _hpTrash;
    [SerializeField] private float _startBonus;
    [SerializeField] private float _priceSpeedProduction;
    [SerializeField] private float _priceHpTrash;
    [SerializeField] private float _priceStartBonus;
    [SerializeField] private int _lvl;

    private void Start()
    {
        //_speedProduction = 1f;
        //PlayerPrefs.SetFloat("Speed", _speedProduction);
        //_hpTrash = 0;
        //PlayerPrefs.SetFloat("Hp", _hpTrash);
        //_startBonus = 0;
        //PlayerPrefs.SetFloat("Bonus", _startBonus);
        //  _lvl = 1;
        //PlayerPrefs.SetInt("LVL", _lvl);
        //PlayerPrefs.SetFloat("Money", 0);
        //PlayerPrefs.Save();

        if (Lvl < SceneManager.GetActiveScene().buildIndex)
        {
            Lvl = SceneManager.GetActiveScene().buildIndex;
        }
    }

    public float SpeedProduction
    {
        get
        {
            _speedProduction = 1;
            if(PlayerPrefs.HasKey("Speed"))
            {
                _speedProduction = Mathf.Floor(PlayerPrefs.GetFloat("Speed") * 100f) / 100f;
            }
            return _speedProduction;
        }
        set
        {
            _speedProduction = Mathf.Floor(value * 100f) / 100f;
            PlayerPrefs.SetFloat("Speed", _speedProduction);
            PlayerPrefs.Save();
        }
    }
    public float HpTrash
    {
        get
        {
            _hpTrash = 0;
            if (PlayerPrefs.HasKey("Hp"))
            {
                _hpTrash = PlayerPrefs.GetFloat("Hp");
            }
            return _hpTrash;
        }
        set
        {
            _hpTrash = value;
            PlayerPrefs.SetFloat("Hp", _hpTrash);
            PlayerPrefs.Save();
        }
    }
    public float StartBonus
    {
        get
        {
            _startBonus = 0;
            if (PlayerPrefs.HasKey("Bonus"))
            {
                _startBonus = PlayerPrefs.GetFloat("Bonus");
            }
            return _startBonus;
        }
        set
        {
            _startBonus = value;
            PlayerPrefs.SetFloat("Bonus", _startBonus);
            PlayerPrefs.Save();
        }
    }
    public int Lvl
    {
        get
        {
            _lvl = 1;
            if (PlayerPrefs.HasKey("LVL"))
            {
                _lvl = PlayerPrefs.GetInt("LVL");
            }
            return _lvl;
        }
        set
        {
            _lvl = (int)value;
            PlayerPrefs.SetInt("LVL", _lvl);
            PlayerPrefs.Save();
        }
    }
    public float PriceSpeed
    {
        get
        {
            _priceSpeedProduction = 25;
            if (PlayerPrefs.HasKey("PriceSpeed"))
            {
                _priceSpeedProduction = Mathf.Ceil(PlayerPrefs.GetFloat("PriceSpeed"));
            }
            return _priceSpeedProduction;
        }
        set
        {
            _priceSpeedProduction = Mathf.Ceil(value);
            PlayerPrefs.SetFloat("PriceSpeed", _priceSpeedProduction);
            PlayerPrefs.Save();
        }
    }
    public float PriceHp
    {
        get
        {
            _priceHpTrash = 20;
            if (PlayerPrefs.HasKey("PriceHp"))
            {
                _priceHpTrash = Mathf.Ceil(PlayerPrefs.GetFloat("PriceHp"));
            }
            return _priceHpTrash;
        }
        set
        {
            _priceHpTrash = Mathf.Ceil(value);
            PlayerPrefs.SetFloat("PriceHp", _priceHpTrash);
            PlayerPrefs.Save();
        }
    }
    public float PriceStart
    {
        get
        {
            _priceStartBonus = 50;
            if (PlayerPrefs.HasKey("PriceStart"))
            {
                _priceStartBonus = Mathf.Ceil(PlayerPrefs.GetFloat("PriceStart"));
            }
            return _priceStartBonus;
        }
        set
        {
            _priceStartBonus = Mathf.Ceil(value);
            PlayerPrefs.SetFloat("PriceStart", _priceStartBonus);
            PlayerPrefs.Save();
        }
    }
}
