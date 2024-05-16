using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerGame : MonoBehaviour
{
    [SerializeField] private Unit _unitSword;
    [SerializeField] private Unit _unitAxe;
    [SerializeField] private Unit _unitStick;
    [SerializeField] private SpawnUnit _spawnUnit;

    public void SpawnSword()
    {
        _spawnUnit.Spawn(_unitSword);
    }
    public void SpawnAxe()
    {
        _spawnUnit.Spawn(_unitAxe);
    }
    public void SpawnStick()
    {
        _spawnUnit.Spawn(_unitStick);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
