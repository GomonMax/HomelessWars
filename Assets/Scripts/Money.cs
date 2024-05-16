using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.VersionControl;

public class Money : MonoBehaviour
{
    [SerializeField] private float _money;
    private TextMeshProUGUI _moneyText;

    private void Start()
    {
        _moneyText = GetComponent<TextMeshProUGUI>();
        _money = MoneyUpdate;
    }

    public float MoneyUpdate
    {
        get
        {
            _money = 0;
            if (PlayerPrefs.HasKey("Money"))
            {
                _money = Mathf.Ceil(PlayerPrefs.GetFloat("Money"));
            }
            ChangeText();
            PlayerPrefs.Save();
            return _money;
        }
        set
        {
            _money = Mathf.Ceil(value);
            PlayerPrefs.SetFloat("Money", _money);
            PlayerPrefs.Save();
            ChangeText();
        }

    }

    public void RewardMoney(float reward)
    {
        _money += reward;
        MoneyUpdate = _money;
        ChangeText();
    }

    void ChangeText()
    {
        _moneyText.text = _money.ToString();
    }
}
