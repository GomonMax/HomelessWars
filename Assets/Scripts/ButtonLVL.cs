using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonLVL : MonoBehaviour
{
    [SerializeField] private UpgradeProperties _upgrateProperties;

    [SerializeField] private Sprite redSprite;
    [SerializeField] private Sprite blueSprite;
    [SerializeField] private int _index;
    private int currentLVL;

    private void Start()
    {
        Button button = GetComponent<Button>();
        Image image = button.GetComponent<Image>();
        currentLVL = _upgrateProperties.Lvl;

        if (currentLVL > _index)
        {
            image.sprite = blueSprite;
        }
        if (currentLVL <= _index)
        {
            image.sprite = redSprite;
        }
    }

    public void StartGame()
    {
        if (currentLVL >= _index)
            SceneManager.LoadScene(_index);
    }
}
