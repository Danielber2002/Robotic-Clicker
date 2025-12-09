using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerController m_player;
    private RoomsController m_roomsController;
    public UIController m_uiController;
    private bool m_gameover = false;


    void Start()
    {
        
    }

    public void StarGame()
    {
        GetComponent<AudioSource>().Play();
        m_player = new PlayerController(10, 100);

        m_uiController.EnableGameUI(true);
        m_uiController.EnableStartButton(false);
        m_uiController.EnableEnemyBar(true);
        m_uiController.EnemyLifeBar(100, 100);
        m_uiController.PlayerLifeBar(m_player.GetCurrentLife(), m_player.GetMaxLife());

        m_gameover = false;
    }

    void Update()
    {
        
    }

    public void PlayerAttack()
    {
        if (!m_gameover)
        {

        }
    }

    public void EnemyAttack(int damage)
    {
        if (!m_player.IsDie())
        {

        }
    }
}
