using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject SpawningPlayer;

    public bool isGameLive, isPlayerAlive = false;
    public bool RunTest = false;
    GameManager gM;

    void Start()
    {
        gM = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {

        if (isGameLive && isPlayerAlive == false)
        {

        }

        if (GameManager.Instance.GameState == GameManager.GameStates.PreGame && isPlayerAlive == false)
        {
            //SpawnPlayer();
        }

    }

    void SpawnePlayerFunction()
    {
            isPlayerAlive = true;
            SpawningPlayer.GetComponent<PlayerController>().isAlive = true;
            Instantiate(SpawningPlayer, transform.position, transform.rotation);
    }
}
