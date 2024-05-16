using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnit : MonoBehaviour
{
    [SerializeField] private Unit _friendlyTrashUnit;
    [SerializeField] private Unit _enemyTrashUnit;
    [SerializeField] private Money _money;
    [SerializeField] private GameObject _units;
    [SerializeField] private Food _food;

    public void Spawn(Unit _unit)
    {
        float price = _unit.UnitStat.Price;

        if (price <= _food._currentFood)
        {
            _food._currentFood -= price;
            Vector3 _positionSpawn = new Vector3(-6, Random.Range(-4.5f, -1.7f), -1);
            Unit newUnit = Instantiate(_unit.gameObject, _positionSpawn, Quaternion.identity).GetComponent<Unit>();
            newUnit.OnCreate(_enemyTrashUnit, _money);
            newUnit.transform.parent = _units.transform;
        }
    }

    public void SpawnEnemy(Unit _unit)
    {
        Vector3 _positionSpawn = new Vector3(6, Random.Range(-4.5f, -1.7f), -1);
        Unit newUnit = Instantiate(_unit.gameObject, _positionSpawn, Quaternion.identity).GetComponent<Unit>();
        newUnit.OnCreate(_friendlyTrashUnit, _money);
        newUnit.transform.parent = _units.transform;
    }
}
