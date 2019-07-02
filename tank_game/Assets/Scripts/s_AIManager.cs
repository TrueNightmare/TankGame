using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class s_AIManager : MonoBehaviour
{
    //NavMeshAgent agent;

    //GameManager gM; 
    //s_playerController thisPlayer;

    //bool isAIenabled = false;

    //int GetPlayerNumber;

    //[SerializeField]
    //GameObject Hunting, player1, player2, player3, player4;

    //[SerializeField]
    //List<GameObject> Huntable = new List<GameObject>();

    //public NavMeshAgent Agent;

    //void Start()
    //{
    //    gM = GameObject.Find("GameManager").GetComponent<GameManager>();
    //    thisPlayer = gameObject.GetComponent<s_playerController>();
    //    //agent = GetComponent<NavMeshAgent>();

    //    GetPlayerNumber = thisPlayer.Player;
    //    if (GetPlayerNumber != 5)
    //    {
    //        //isAIenabled = !gM.ReturnPlayerOnlineStatesAI(GetPlayerNumber);
    //    }

    //    FindingHuntingList();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (thisPlayer.isAi == true)
    //        isAIenabled = true;
    //    if (isAIenabled)
    //    {            
    //        if (gM.GameState == GameManager.GameStates.Game)
    //        {
    //            if (Hunting == null)
    //            {
    //                FindHunting();
    //            }
    //            else
    //            {
    //                if (Hunting.GetComponent<s_playerController>().isAlive)
    //                {                        
    //                    agent.SetDestination(Hunting.transform.position);
    //                }
    //                else
    //                {
    //                    FindHunting();
    //                }
    //            }
    //        }
    //    }
    //}

    //void FindingHuntingList()
    //{
    //    player1 = GameObject.Find("p_player_blue");
    //    player2 = GameObject.Find("p_player_red");
    //    player3 = GameObject.Find("p_player_yellow");
    //    player4 = GameObject.Find("p_player_green");

    //    if (thisPlayer.Player != 1 && player1 != null)
    //        Huntable.Add(player1);
    //    if (thisPlayer.Player != 2 && player2 != null)
    //        Huntable.Add(player2);
    //    if (thisPlayer.Player != 3 && player3 != null)
    //        Huntable.Add(player3);
    //    if (thisPlayer.Player != 4 && player4 != null)
    //        Huntable.Add(player4);

    //    Debug.Log("Huntable Size: " + Huntable.Count);

    //    FindHunting();
    //}

    //void FindHunting()
    //{
    //    Hunting = Huntable[RandomRange(0, Huntable.Count)].gameObject;
    //}

    //int RandomRange(int min, int max)
    //{
    //    return Random.Range(min, max);
    //}
}
