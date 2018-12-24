using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_spawnPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject SpawningPlayer;

    public bool isGameLive, isPlayerAlive = false;
    public bool RunTest = false;
    GameManager gM;

    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isGameLive && isPlayerAlive == false)
        {

        }

        if (gM.GameState == GameManager.GameStates.PreGame && isPlayerAlive == false)
        {
            SpawnPlayer();
        }

    }

    void SpawnPlayer()
    {
            isPlayerAlive = true;
            SpawningPlayer.GetComponent<s_playerController>().isAlive = true;
            Debug.Log("Player 1 Spawned");
            Instantiate(SpawningPlayer, transform);
    }
}
