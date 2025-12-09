using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject m_gameUI;
    public GameObject m_startButton;
    public Image m_enemyLife;
    public Image m_playerLife;


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void EnableGameUI(bool isActive)
    {
        m_gameUI.SetActive(isActive);
    }

    public void EnableStartButton(bool isActive)
    {
        m_startButton.SetActive(isActive);
    }

    public void EnableEnemyBar(bool isActive)
    {
        m_enemyLife.gameObject.SetActive(isActive);
    }

    public void EnemyLifeBar ( int amount, int maxLife)
    {
        m_enemyLife.fillAmount = amount / maxLife;
    }

    public void PlayerLifeBar(int amount, int maxLife)
    {
        m_playerLife.fillAmount = amount / maxLife;
    }
}
