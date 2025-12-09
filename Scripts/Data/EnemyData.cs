using UnityEngine;

[System.Serializable]

public class EnemyData : MonoBehaviour
{
   public string m_name;
    public int m_damage;
    public int m_defense;
    public int m_maxlife;
    public int m_rewardExperience;
    public float m_timeBetweenAttacks;
    public int m_percentageStrongAttacks;

    public int m_currentlife;

    public EnemyData (string name, int damage, int defense, int maxlife, int rewardExperience, int timeBetweenAttacks, int percentageStrongAttacks)
        {
        m_name = name;
        m_damage = damage;
        m_defense = defense;
        m_maxlife = maxlife;
        m_rewardExperience = rewardExperience;
        m_timeBetweenAttacks = timeBetweenAttacks;
        m_percentageStrongAttacks = percentageStrongAttacks;

        m_currentlife = maxlife;
    }
}
