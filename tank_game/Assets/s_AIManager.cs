using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class s_AIManager : MonoBehaviour
{
    GameManager gM; 
    s_playerController thisPlayer;

    bool isAIenabled = false;

    int GetPlayerNumber;

    public bool Hunt1Player = false, Hunt2Player = false, Hunt3Player = false, Hunt4Player = false;

    GameObject Hunting;

    public NavMeshAgent Agent;

    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        thisPlayer = gameObject.GetComponent<s_playerController>();

        GetPlayerNumber = thisPlayer.Player;
        if (GetPlayerNumber != 5)
        {
            isAIenabled = !gM.ReturnPlayerOnlineStatesAI(GetPlayerNumber);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isAIenabled)
        {
            if (gM.GameState == GameManager.GameStates.Game)
            {
                
            }
        }
    }

    void FindClosetAlivePlayer()
    {
        GameObject Player1, Player2, Player3, Player4;
        if (GetPlayerNumber != 1)
        {
            Player1 = GameObject.Find("p_player_blue(clone)");
        }
        if (GetPlayerNumber != 2)
        {
            try
            {
                Player2 = GameObject.Find("p_player_red(clone)");
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
