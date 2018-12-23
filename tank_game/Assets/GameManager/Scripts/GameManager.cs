using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameStates { none, Start, Menus, Game, PreGame, EndGame };
    public GameStates GameState;
    
    public enum GameModes { FreeForAll, Elimiation, Torrentment };
    public GameModes GamdeMode;

    public bool isPlayer1, isPlayer2, isPlayer3, isPlayer4;

    //MainMenu Only

    public Canvas PlayerConnected;
    
    //end

    public static GameManager instance;
    // Use this for initialization
    void Awake()
    {
        if (instance == null)
            instance = this;

        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            GameState = GameStates.Start;
        }
        else
        {
            GameState = GameStates.Game;
        }
    }

    private void Update()
    {

        switch (GameState)
        {
            case GameStates.none:
                break;
            case GameStates.Start:
                if (Input.GetButtonDown("p1_start"))
                {
                    isPlayer1 = true;
                    GameState = GameStates.Menus;
                }
                if (Input.GetButtonDown("p2_start"))
                {
                    isPlayer2 = true;
                    GameState = GameStates.Menus;
                }
                if (Input.GetButtonDown("p3_start"))
                {
                    isPlayer3 = true;
                    GameState = GameStates.Menus;
                }
                if (Input.GetButtonDown("p4_start"))
                {
                    isPlayer4 = true;
                    GameState = GameStates.Menus;
                }
                break;
            case GameStates.Menus:
                LoadMenuComponets();
                break;
            case GameStates.Game:
                break;
            case GameStates.PreGame:
                break;
            case GameStates.EndGame:
                break;
            default:
                break;
        }
    }

    void LoadMenuComponets()
    {

    }
}
