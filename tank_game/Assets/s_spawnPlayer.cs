using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_spawnPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject SpawningPlayer;

    public bool isGameLive, isPlayerAlive = false;
    public bool RunTest = false;

    // Update is called once per frame
    void Update()
    {
        if (isGameLive && isPlayerAlive == false)
        {

        }

        if (Input.GetButtonDown("p1_start"))
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
