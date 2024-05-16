using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private SpawnUnit _spawnUnit;

    [SerializeField] private Unit []_unitEnemy;
    [SerializeField] private float _interval;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(_interval);
            _spawnUnit.SpawnEnemy(_unitEnemy[Random.Range(0, 3)]);
        }
    }
}
