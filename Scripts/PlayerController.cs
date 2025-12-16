using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController 
{
    private int m_damage;
    private int m_defense;
    private int m_maxLife;
    private int m_currentLife;

    public PlayerController(int damage,int defense, int maxLife)
    {
        m_damage = damage;
        m_defense = defense;
        m_currentLife = maxLife;
        m_maxLife = maxLife;
    }

    public void ReceiveDamage(int damage)
    {
        int currentDamage = damage - m_defense;
        if(currentDamage > 0)
        {
            m_currentLife -= damage - m_defense;
            Debug.Log("Ay!");
        }
    }
    public void HealDamage(int heal)
    {
            m_currentLife += heal;
    }

    public int Attack(EnemyData enemy)
    {
        int damageAux = m_damage;

        return damageAux;
    }

    public int GetCurrentLife()
    {
        return m_currentLife;
    }

    public int GetMaxLife()
    {
        return m_maxLife;
    }

    public bool IsDie() 
    {
        if (m_currentLife < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Start()
    {
                
    }

 
    void Update()
    {
        
    }
}
