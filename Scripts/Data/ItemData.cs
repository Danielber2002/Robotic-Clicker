using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
   public string m_name;
    public int m_lifeUp;
    public int m_damageUp;
    public int m_defenseUp;

    public ItemData (string name, int lifeUp, int damageUp, int defenseUp)
    {
        m_name = name;
        m_lifeUp = lifeUp;
        m_damageUp = damageUp;
        m_defenseUp = defenseUp;
    }
}
