using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private PlayerController m_player;
    private RoomsController m_roomController;
    public UIController m_uiController;
    private LabyrinthData m_labyrinth;
    public EnemyData m_enemyData;
    private bool m_gameOver = false;
    private float m_points = 0;
    public TextMeshProUGUI pointsText;
    private GameObject m_gameOverScreen;
    private TextMeshProUGUI m_gameOverScreenText;

    private SpriteSelector m_spriteSelector;


    void Start()
    {
       m_spriteSelector = GetComponent<SpriteSelector>();
       m_gameOverScreen = m_uiController.gameOverScreen;
       m_gameOverScreenText = m_uiController.gameOverScreen.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void StarGame()
    {
        GetComponent<AudioSource>().Play();

        // CREMOS EL LABERINTO QUE CONTIENE LAS HABITACIONES
        m_labyrinth = new LabyrinthData();

        //AÑADE HABITACIONES AL LABERINTO
        TrapData trap = new TrapData("Pinchos", -10);
        RoomData room = new RoomData(trap);
        m_labyrinth.AddRoom(room);

        ItemData item = new ItemData("Item 1", 10, 0, 0);
        room = new RoomData(item);
        m_labyrinth.AddRoom(room);

        EnemyData enemy = new EnemyData("Enemy 1", 15, 3, 60, 20, 2,30);
        room = new RoomData(enemy);
        m_labyrinth.AddRoom(room);

        m_player = new PlayerController(10, 2, 100);

        m_uiController.EnableGameUI(true);
        m_uiController.EnableStartButton(false);
        m_uiController.EnableEnemyBar(true);
        m_uiController.EnemyLifeBar(100, 100);
        m_uiController.PlayerLifeBar(m_player.GetCurrentLife(), m_player.GetMaxLife());

        m_gameOver = false;

        // ARRANCA EL LABERINTO
        ChangeRoom();
    }

    public void ChangeRoom()
    {
        m_points += 10;
        CheckPoints();

        m_labyrinth.ChangeRoom();

        if (m_labyrinth.IsFinished())
        {
          m_gameOverScreen.SetActive(true);
          m_gameOverScreenText.text = "¡HAS GANADO!";
          Debug.Log("FINISH LABYRINTH");
          m_uiController.EnableGameUI(false);
          m_uiController.EnableStartButton(true);
          
          //GAME END
          m_roomController.DisableRooms();
            m_gameOver = true;

            StartCoroutine(nameof(FinishLabyrinth));
            return;
        }

        switch (m_labyrinth.GetCurrentRoom().m_roomType)
        {
            case RoomData.RoomType.ENEMY:
                m_uiController.EnableEnemyBar(true);
                m_roomController.SetRoom(m_labyrinth.GetCurrentRoom().m_enemy, m_spriteSelector.GetEnemySpriteByName(m_labyrinth.GetCurrentRoom().m_enemy.m_name));
                break;
            case RoomData.RoomType.ITEM:
                m_uiController.EnableEnemyBar(false);
                m_roomController.SetRoom(m_labyrinth.GetCurrentRoom().m_item, m_spriteSelector.GetItemSpriteByName(m_labyrinth.GetCurrentRoom().m_item.m_name));
                break;
            case RoomData.RoomType.TRAP:
                m_uiController.EnableEnemyBar(false);
                m_roomController.SetRoom(m_labyrinth.GetCurrentRoom().m_trap, m_spriteSelector.GetTrapSpriteByName(m_labyrinth.GetCurrentRoom().m_trap.m_name));
                break;
            default:
                break;
        }
    }

    IEnumerator FinishLabyrinth()
    {
       yield return new WaitForSecondsRealtime(2.5f);
       m_gameOverScreen.SetActive(false);
    }


    void Update()
    {

    }

    public void CheckPoints()
    {
        pointsText.text = m_points.ToString("0");
    }

    public void PlayerAttack()
    {
        if (!m_gameOver)
        {
            if (m_labyrinth.GetCurrentRoom().m_roomType == RoomData.RoomType.ENEMY)
            {
                int damageToApply = m_player.Attack(m_roomController.GetEnemyRoom().GetComponent<EnemyBehaviour>().m_enemyData);
                m_roomController.GetEnemyRoom().GetComponent<EnemyBehaviour>().RecieveDamage(damageToApply);
                m_uiController.EnemyLifeBar(m_roomController.GetEnemyRoom().GetComponent<EnemyBehaviour>().m_enemyData.m_currentLife,
                   m_roomController.GetEnemyRoom().GetComponent<EnemyBehaviour>().m_enemyData.m_maxlife);

                if (m_roomController.GetEnemyRoom().GetComponent<EnemyBehaviour>().IsDie())
                {
                   Debug.Log("ENEMY IS DIE");
                    ChangeRoom ();
                }
            }
        }
    }

    public void EnemyAttack(int damage)
    {
        m_player.ReceiveDamage(damage);
        m_uiController.PlayerLifeBar(m_player.GetCurrentLife(), m_player.GetMaxLife());

        if (m_player.IsDie())
        {
            m_uiController.EnableGameUI(false);
            m_uiController.EnableStartButton(true);
            m_gameOverScreen.SetActive(true);
            m_gameOverScreenText.text = "¡HAS PERDIDO";
            m_roomController.DisableRooms();
            m_gameOver = true;
        }
    }

    public void ApplyTrap(int damage)
    {
        m_player.ReceiveDamage(damage);
        m_uiController.PlayerLifeBar(m_player.GetCurrentLife(), m_player.GetMaxLife());

    }

    public void ApplyItem(int heal)
    {
        m_player.HealDamage(heal);
        m_uiController.PlayerLifeBar(m_player.GetCurrentLife(), m_player.GetMaxLife());

    }

}
