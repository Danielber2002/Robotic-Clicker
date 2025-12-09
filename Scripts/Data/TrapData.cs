using UnityEngine;

public class TrapData : MonoBehaviour
{
    public string m_name;
    public int m_playerDamage;

    public TrapData (string name, int playerDamage)
    {
        m_name = name;
        m_playerDamage = playerDamage;
    }
}
