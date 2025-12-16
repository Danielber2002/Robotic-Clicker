using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealGameObjectSelector : MonoBehaviour
{
    public List<NameGameObjectTupla> m_enemyGameObjectTupla;
    public List<NameGameObjectTupla> m_itemGameObjectTupla;
    public List<NameGameObjectTupla> m_trapGameObjectTupla;


    public GameObject GetEnemyGameObjectByName(string name)
    {
        for (int i = 0; i < m_enemyGameObjectTupla.Count; i++)
        {
            if (m_enemyGameObjectTupla[i].m_name.Equals(name))
            {
                return m_enemyGameObjectTupla[i].m_GameObject;
            }
        }

        return null;
    }

    public GameObject GetTrapGameObjectByName(string name)
    {
        for (int i = 0; i < m_trapGameObjectTupla.Count; i++)
        {
            if (m_trapGameObjectTupla[i].m_name.Equals(name))
            {
                return m_trapGameObjectTupla[i].m_GameObject;
            }
        }

        return null;
    }

    public GameObject GetItemGameObjectByName(string name)
    {
        for (int i = 0; i < m_itemGameObjectTupla.Count; i++)
        {
            if (m_itemGameObjectTupla[i].m_name.Equals(name))
            {
                return m_itemGameObjectTupla[i].m_GameObject;
            }
        }

        return null;
    }
}