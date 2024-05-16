using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit", order = 51)]
public class UnitsStatistic : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private float _damage;
    [SerializeField] private float _hp;
    [SerializeField] private float _speed;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _reward;
    [SerializeField] private float _price;

    public string Name
    {
        get
        {
            return _name;
        }
    }
    public float Damage
    {
        get
        {
            return _damage;
        }
    }
    public float HP
    {
        get
        {
            return _hp;
        }
    }
    public float Speed
    {
        get
        {
            return _speed;
        }
    }
    public float AttackSpeed
    {
        get
        {
            return _attackSpeed;
        }
    }
    public float Reward
    {
        get
        {
            return _reward;
        }
    }
    public float Price
    {
        get
        {
            return _price;
        }
    }
}
