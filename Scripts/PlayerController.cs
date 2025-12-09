using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int m_damage;
    private int m_maxLife;
    private int m_currentLife;

    public PlayerController(int damage, int maxLife)
    {
        m_damage = damage;
        m_maxLife = maxLife;
    }

    public int Attack()
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
