using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashHP : MonoBehaviour
{
    private TextMeshPro _hpText;
    [SerializeField] private Unit _unit;

    private void Start()
    {
        _hpText = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        _hpText.text = _unit.hp.ToString();
    }
}
