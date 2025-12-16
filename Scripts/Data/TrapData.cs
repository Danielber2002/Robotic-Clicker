using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapData 
{
    public string m_name;
    public int m_playerDamage;

    public TrapData (string name, int playerDamage)
    {
        m_name = name;
        m_playerDamage = playerDamage;
    }
}
