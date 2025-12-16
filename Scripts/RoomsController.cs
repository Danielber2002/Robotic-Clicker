using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsController : MonoBehaviour
{
    public GameObject m_enemyRoomDuracell1;
    public GameObject m_enemyRoomDuracell2;
    public GameObject m_enemyRoomExMichelin1;
    public GameObject m_enemyRoomExMichelin2;
    public GameObject m_enemyRoomConga1;
    public GameObject m_enemyRoomConga2;
    public GameObject m_itemRoom;
    public GameObject m_trapRoom;
    public GameObject m_enemyRoom;

    public GameObject m_enemyRoomDuracell1Prefab;
    public GameObject m_enemyRoomDuracell2Prefab;
    public GameObject m_enemyRoomExMichelin1Prefab;
    public GameObject m_enemyRoomExMichelin2Prefab;
    public GameObject m_enemyRoomConga1Prefab;
    public GameObject m_enemyRoomConga2Prefab;
    public GameObject m_itemRoomPrefab;
    public GameObject m_trapRoomPrefab;

 
    public void SetRoom(EnemyData data, GameObject spriteObject, int index)
    {
       
        m_enemyRoomDuracell1.SetActive(false);
        m_enemyRoomDuracell2.SetActive(false);
        m_enemyRoomExMichelin1.SetActive(false);
        m_enemyRoomExMichelin2.SetActive(false);
        m_enemyRoomConga1.SetActive(false);
        m_enemyRoomConga2.SetActive(false);

        switch(index)
        {
            
            case 0:
                m_enemyRoomDuracell1.SetActive(true);
                m_enemyRoomDuracell1.GetComponent<EnemyBehaviour>().SetEnemy(data);
                m_enemyRoomDuracell1Prefab = spriteObject;
                m_enemyRoom = m_enemyRoomDuracell1;
                break;
            case 1:
                m_enemyRoomDuracell2.SetActive(true);
                m_enemyRoomDuracell2.GetComponent<EnemyBehaviour>().SetEnemy(data);
                m_enemyRoomDuracell2Prefab = spriteObject;
                m_enemyRoom = m_enemyRoomDuracell2;
                break;
            case 2:
                m_enemyRoomExMichelin1.SetActive(true);
                m_enemyRoomExMichelin1.GetComponent<EnemyBehaviour>().SetEnemy(data);
                m_enemyRoomExMichelin1Prefab = spriteObject;
                m_enemyRoom = m_enemyRoomExMichelin1;
                break;
            case 3:
                m_enemyRoomExMichelin2.SetActive(true);
                m_enemyRoomExMichelin2.GetComponent<EnemyBehaviour>().SetEnemy(data);
                m_enemyRoomExMichelin2Prefab = spriteObject;
                m_enemyRoom = m_enemyRoomExMichelin2;
                break;
            case 4:
                m_enemyRoomConga1.SetActive(true);
                m_enemyRoomConga1.GetComponent<EnemyBehaviour>().SetEnemy(data);
                m_enemyRoomConga1Prefab = spriteObject;
                m_enemyRoom = m_enemyRoomConga1;
                break;
            case 5:
                m_enemyRoomConga2.SetActive(true);
                m_enemyRoomConga2.GetComponent<EnemyBehaviour>().SetEnemy(data);
                m_enemyRoomConga2Prefab = spriteObject;
                m_enemyRoom = m_enemyRoomConga2;
                break;
        }

        m_itemRoom.SetActive(false);
        m_trapRoom.SetActive(false);
        
        
    }
    public void SetRoom(TrapData data, GameObject spriteObject)
    {
        m_enemyRoomDuracell1.SetActive(false);
        m_enemyRoomDuracell2.SetActive(false);
        m_enemyRoomExMichelin1.SetActive(false);
        m_enemyRoomExMichelin2.SetActive(false);
        m_enemyRoomConga1.SetActive(false);
        m_enemyRoomConga2.SetActive(false);
        m_itemRoom.SetActive(false);
        m_trapRoom.SetActive(true);
        //
        m_trapRoomPrefab = spriteObject;
    }

    public void SetRoom(ItemData data, GameObject spriteObject)
    {
        m_enemyRoomDuracell1.SetActive(false);
        m_enemyRoomDuracell2.SetActive(false);
        m_enemyRoomExMichelin1.SetActive(false);
        m_enemyRoomExMichelin2.SetActive(false);
        m_enemyRoomConga1.SetActive(false);
        m_enemyRoomConga2.SetActive(false);
        m_itemRoom.SetActive(true);
        m_trapRoom.SetActive(false);
        //
        m_itemRoomPrefab = spriteObject;
    }

    public void DisableRooms()
    {
        m_enemyRoomDuracell1.SetActive(false);
        m_enemyRoomDuracell2.SetActive(false);
        m_enemyRoomExMichelin1.SetActive(false);
        m_enemyRoomExMichelin2.SetActive(false);
        m_enemyRoomConga1.SetActive(false);
        m_enemyRoomConga2.SetActive(false);
        m_itemRoom.SetActive(false);
        m_trapRoom.SetActive(false);
    }

    public GameObject GetEnemyRoom()
    {
        return m_enemyRoom;
    }


}
