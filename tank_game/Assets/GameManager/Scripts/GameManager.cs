using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public enum GameStates { none, Start, Menus, Game, PreGame, EndGame };
    public GameStates GameState;
    
    public enum GameModes { FreeForAll, Elimiation, Torrentment };
    public GameModes GameMode;

    public bool isPlayer1, isPlayer2, isPlayer3, isPlayer4;
    public bool isPlayer1Alive, isPlayer2Alive, isPlayer3Alive, isPlayer4Alive;

    public float Minutes, MatchTimer, CountDownTimer, CountDownCatch;

    public int ScoreLimit = 5, PlayerCount;

    public bool ScoreLimitReached = false;

    public Scene[] Levels2PlayerVS;
    public Scene[] Levels3PlayerVS;
    public Scene[] Levels4PlayerVS;
    //MainMenu Only

    public GameObject PlayerConnected;
    public TextMeshProUGUI CountDownScreenText;
    
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

        }
        switch (GameState)
        {
            case GameStates.none:
                Debug.LogError("GameManager should never be in the None state");
                break;
            case GameStates.Start:
                PlayerConnected = GameObject.Find("player_connected");
                break;
            case GameStates.Menus:
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
        ConvertMinutesToMatchTime();
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
                    isPlayer1 = !isPlayer1;
                    GameState = GameStates.Menus;
                    PlayerConnected.GetComponent<s_player_connected>().ControllerEnabed();
                }
                if (Input.GetButtonDown("p2_start"))
                {
                    isPlayer2 = !isPlayer2;
                    GameState = GameStates.Menus;
                    PlayerConnected.GetComponent<s_player_connected>().ControllerEnabed();
                }
                if (Input.GetButtonDown("p3_start"))
                {
                    isPlayer3 = !isPlayer3;
                    GameState = GameStates.Menus;
                    PlayerConnected.GetComponent<s_player_connected>().ControllerEnabed();
                }
                if (Input.GetButtonDown("p4_start"))
                {
                    isPlayer4 = !isPlayer4;
                    GameState = GameStates.Menus;
                    PlayerConnected.GetComponent<s_player_connected>().ControllerEnabed();
                }
                break;
            case GameStates.Menus:
                LoadMenuComponets();
                break;
            case GameStates.Game:
                MatchTimer -= Time.deltaTime;
                switch (GameMode)
                {
                    case GameModes.FreeForAll:      //Free for all GameMode

                        if (MatchTimer < 0 || ScoreLimitReached)
                        {
                            GameState = GameStates.EndGame;
                        }

                        break;
                    case GameModes.Elimiation:

                        PlayerCount = 0;
                        if (isPlayer1Alive == true)
                        {
                            PlayerCount++;
                        }
                        if (isPlayer2Alive == true)
                        {
                            PlayerCount++;
                        }
                        if (isPlayer3Alive == true)
                        {
                            PlayerCount++;
                        }
                        if (isPlayer4Alive == true)
                        {
                            PlayerCount++;
                        }

                        if (PlayerCount <= 1)
                        {
                            GameState = GameStates.EndGame;
                        }

                        break;
                    case GameModes.Torrentment:
                        break;
                }
                
                
                break;
            case GameStates.PreGame:
                CountDownScreenText = GameObject.Find("CountDown_Screen").GetComponent<TextMeshProUGUI>();
                CountDownTimer += Time.deltaTime;
                if (CountDownTimer > 1)
                {
                    CountDownCatch++;
                    CountDownTimer = 0f;
                    switch (CountDownCatch)
                    {
                        case 1:
                            Debug.Log("3");
                            CountDownScreenText.text = "3";
                            break;
                        case 2:
                            Debug.Log("2");
                            CountDownScreenText.text = "2";
                            break;
                        case 3:
                            Debug.Log("1");
                            CountDownScreenText.text = "1";
                            break;
                        case 4:
                            Debug.Log("GO!");
                            CountDownScreenText.text = "GO!";
                            break;
                        case 5:
                            Debug.Log("This is so Go disappers");
                            CountDownScreenText.text = "";
                            GameState = GameStates.Game;
                            break;
                        default:
                            break;
                    }
                }
                break;
            case GameStates.EndGame:
                break;
            default:
                break;
        }

        if (Input.GetButtonDown("p1_quit") || Input.GetButtonDown("p2_quit") || Input.GetButtonDown("p3_quit") || Input.GetButtonDown("p4_quit"))
        {
            Application.Quit();
        }
    }

    void LoadMenuComponets()
    {

    }
    void LoadStartComponets()
    {
        PlayerConnected = GameObject.Find("player_connected");
    }
    void ConvertMinutesToMatchTime()
    {
        MatchTimer = Minutes * 60f;
    }
    public void ScoreLimitAchived()
    {
        ScoreLimitReached = !ScoreLimitReached;
    }

    public bool ReturnPlayerOnlineStatesAI(int Player)
    {
        switch (Player)
        {
            case 1:
                return isPlayer1;
            case 2:
                return isPlayer2;
            case 3:
                return isPlayer3;
            case 4:
                return isPlayer4;
            default:
                break;
        }

        return true;
    }
}
