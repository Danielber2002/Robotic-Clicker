using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private PlayerController m_player;
    [SerializeField] private RoomsController m_roomController;
    public UIController m_uiController;
    private LabyrinthData m_labyrinth;
    public EnemyData m_enemyData;
    private bool m_gameOver = false;
    private float m_points = 0;
    public TextMeshProUGUI pointsText;
    private GameObject m_gameOverScreen;
    private TextMeshProUGUI m_gameOverScreenText;

    private RealGameObjectSelector m_GameObjectSelector;


    void Start()
    {
       m_GameObjectSelector = GetComponent<RealGameObjectSelector>();
       m_gameOverScreen = m_uiController.gameOverScreen;
       m_gameOverScreenText = m_uiController.gameOverScreen.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void StarGame()
    {
        GetComponent<AudioSource>().Play();

        // CREMOS EL LABERINTO QUE CONTIENE LAS HABITACIONES
        m_labyrinth = new LabyrinthData();

        int randomNum = Random.Range(15, 25);

        //AÑADE HABITACIONES AL LABERINTO
        TrapData trap1 = new TrapData("Pinchos", -10);
        TrapData trap2 = new TrapData("Aceite", -5);
        ItemData item1 = new ItemData("Heal", 10, 0, 0);
        ItemData item2 = new ItemData("Armor", 0, 0, 1);
        ItemData item3 = new ItemData("Damage", 0, 1, 0);
        EnemyData ExMichelin1 = new EnemyData("ExMichelin", 15, 3, 60, 20, 2, 30);
        EnemyData ExMichelin2 = new EnemyData("ExMichelin", 15, 3, 60, 20, 2, 30);
        EnemyData DuracellRobot1 = new EnemyData("DuracellRobot", 15, 3, 60, 20, 2, 30);
        EnemyData DuracellRobot2 = new EnemyData("DuracellRobot", 15, 3, 60, 20, 2, 30);
        EnemyData AssasinConga1 = new EnemyData("AssasinConga", 15, 3, 60, 20, 2, 30);
        EnemyData AssasinConga2 = new EnemyData("AssasinConga", 15, 3, 60, 20, 2, 30);
        RoomData room;

        for (int i = 0; i < randomNum; i++)
        {
            int randomRoom = Random.Range(0, 11);
            switch (randomRoom)
            {
                case 0:
                    room = new RoomData(trap1);
                    m_labyrinth.AddRoom(room);
                    break;
                case 1:
                    room = new RoomData(trap2);
                    m_labyrinth.AddRoom(room);
                    break;
                case 2:
                    room = new RoomData(item1);
                    m_labyrinth.AddRoom(room);
                    break;
                case 3:
                    room = new RoomData(item2);
                    m_labyrinth.AddRoom(room);
                    break;
                case 4:
                    room = new RoomData(item3);
                    m_labyrinth.AddRoom(room);
                    break;
                case 5:
                    room = new RoomData(ExMichelin1, 2);
                    m_labyrinth.AddRoom(room);
                    break;
                case 6:
                    room = new RoomData(ExMichelin2, 3);
                    m_labyrinth.AddRoom(room);
                    break;
                case 7:
                    room = new RoomData(DuracellRobot1, 0);
                    m_labyrinth.AddRoom(room);
                    break;
                case 8:
                    room = new RoomData(DuracellRobot2, 1);
                    m_labyrinth.AddRoom(room);
                    break;
                case 9:
                    room = new RoomData(AssasinConga1, 4);
                    m_labyrinth.AddRoom(room);
                    break;
                case 10:
                    room = new RoomData(AssasinConga2, 5);
                    m_labyrinth.AddRoom(room);
                    break;

                default:
                    break;
            }
        }


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
                m_roomController.SetRoom(m_labyrinth.GetCurrentRoom().m_enemy, m_GameObjectSelector.GetEnemyGameObjectByName(m_labyrinth.GetCurrentRoom().m_enemy.m_name), m_labyrinth.GetCurrentRoom().m_index);
                break;
            case RoomData.RoomType.ITEM:
                m_uiController.EnableEnemyBar(false);
                m_roomController.SetRoom(m_labyrinth.GetCurrentRoom().m_item, m_GameObjectSelector.GetItemGameObjectByName(m_labyrinth.GetCurrentRoom().m_item.m_name));
                break;
            case RoomData.RoomType.TRAP:
                m_uiController.EnableEnemyBar(false);
                m_roomController.SetRoom(m_labyrinth.GetCurrentRoom().m_trap, m_GameObjectSelector.GetTrapGameObjectByName(m_labyrinth.GetCurrentRoom().m_trap.m_name));
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
