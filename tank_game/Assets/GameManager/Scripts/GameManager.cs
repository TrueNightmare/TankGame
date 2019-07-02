using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }


    [Header("Developer Settings")]
    public GameStates GameState;
    public enum GameStates { none, Menus, PreGame, Game, EndGame };

    public GameModes GameMode;
    public enum GameModes { FreeForAll, Elimiation, Torrentment };

    [Header ("Players Connected")]
    public bool isPlayer1;
    public bool isPlayer2;
    public bool isPlayer3;
    public bool isPlayer4;

    [Header("Player Colours")]
    public Color[] PlayerColours;
    public Material[] PlayerTextures;

    // Use this for initialization
    void Awake()
    {
        if (Instance == null)
            Instance = this;

        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetButtonDown("p1_start") && isPlayer1 == false)
        {
            isPlayer1 = true;
        }
        if (Input.GetButtonDown("p2_start") && isPlayer2 == false)
        {
            isPlayer2 = true;
        }
        if (Input.GetButtonDown("p3_start") && isPlayer3 == false)
        {
            isPlayer3 = true;
        }
        if (Input.GetButtonDown("p4_start") && isPlayer4 == false)
        {
            isPlayer4 = true;
        }
    }

    public void StartGame(GameModes Gm, string LevelName)
    {
        GameMode = Gm;

        if (Application.CanStreamedLevelBeLoaded(LevelName))
        {
            SceneManager.LoadScene(LevelName, LoadSceneMode.Single);
        }
        else
        {
            Debug.LogWarning("Unable to load level, does name exist or has it been added to build? Tried to load: " + LevelName);
        }
    }

    //private void Start()
    //{
    //    if (SceneManager.GetActiveScene().name == "MainMenu")
    //    {
    //        GameState = GameStates.Start;
    //    }
    //    else
    //    {

    //    }
    //    switch (GameState)
    //    {
    //        case GameStates.none:
    //            Debug.LogError("GameManager should never be in the None state");
    //            break;
    //        case GameStates.Start:
    //            PlayerConnected = GameObject.Find("player_connected");
    //            break;
    //        case GameStates.Menus:
    //            break;
    //        case GameStates.Game:
    //            break;
    //        case GameStates.PreGame:
    //            break;
    //        case GameStates.EndGame:
    //            break;
    //        default:
    //            break;
    //    }
    //    ConvertMinutesToMatchTime();
    //}

    //private void Update()
    //{

    //    switch (GameState)
    //    {
    //        case GameStates.none:
    //            break;
    //        case GameStates.Start:
    //            CanvasChanger();
    //            if (Input.GetButtonDown("p1_start"))
    //            {
    //                isPlayer1 = !isPlayer1;
    //                GameState = GameStates.Menus;
    //                PlayerConnected.GetComponent<s_player_connected>().ControllerEnabed();
    //            }
    //            if (Input.GetButtonDown("p2_start"))
    //            {
    //                isPlayer2 = !isPlayer2;
    //                GameState = GameStates.Menus;
    //                PlayerConnected.GetComponent<s_player_connected>().ControllerEnabed();
    //            }
    //            if (Input.GetButtonDown("p3_start"))
    //            {
    //                isPlayer3 = !isPlayer3;
    //                GameState = GameStates.Menus;
    //                PlayerConnected.GetComponent<s_player_connected>().ControllerEnabed();
    //            }
    //            if (Input.GetButtonDown("p4_start"))
    //            {
    //                isPlayer4 = !isPlayer4;
    //                GameState = GameStates.Menus;
    //                PlayerConnected.GetComponent<s_player_connected>().ControllerEnabed();
    //            }
    //            break;
    //        case GameStates.Menus:
    //            CanvasChanger();
    //            LoadMenuComponets();
    //            break;
    //        case GameStates.Game:
    //            CanvasChanger();
    //            MatchTimer -= Time.deltaTime;
    //            switch (GameMode)
    //            {
    //                case GameModes.FreeForAll:      //Free for all GameMode

    //                    if (MatchTimer < 0 || ScoreLimitReached)
    //                    {
    //                        GameState = GameStates.EndGame;
    //                    }

    //                    break;
    //                case GameModes.Elimiation:

    //                    PlayerCount = 0;
    //                    TestToSeeHowManyAreLive();

    //                    break;
    //                case GameModes.Torrentment:
    //                    break;
    //            }
    //            break;
    //        case GameStates.PreGame:
    //            CanvasChanger();
    //            CountDownScreenText = GameObject.Find("CountDown_Screen").GetComponent<TextMeshProUGUI>();
    //            CountDownTimer += Time.deltaTime;
    //            if (CountDownTimer > 1)
    //            {
    //                CountDownCatch++;
    //                CountDownTimer = 0f;
    //                switch (CountDownCatch)
    //                {
    //                    case 1:
    //                        Debug.Log("3");
    //                        CountDownScreenText.text = "3";
    //                        break;
    //                    case 2:
    //                        Debug.Log("2");
    //                        CountDownScreenText.text = "2";
    //                        break;
    //                    case 3:
    //                        Debug.Log("1");
    //                        CountDownScreenText.text = "1";
    //                        break;
    //                    case 4:
    //                        Debug.Log("GO!");
    //                        CountDownScreenText.text = "GO!";
    //                        break;
    //                    case 5:
    //                        Debug.Log("This is so Go disappers");
    //                        CountDownScreenText.text = "";
    //                        GameState = GameStates.Game;
    //                        break;
    //                    default:
    //                        break;
    //                }

    //                if (GameMode == GameManager.GameModes.Elimiation)
    //                {
    //                    TestToSeeHowManyAreLive();
    //                }
    //            }
    //            break;
    //        case GameStates.EndGame:
    //            CanvasChanger();
    //            switch (GameMode)
    //            {
    //                case GameModes.FreeForAll:
    //                    CountDownScreenText.text = "Winner! Player " + Winner + " With " + WinningScore + " Points";
    //                    break;
    //                case GameModes.Elimiation:
    //                    TestToSeeHowManyAreLive();
    //                    if (PlayerCount > 1)
    //                    {
    //                        CountDownScreenText.text = "Draw";
    //                    }
    //                    else
    //                    {
    //                        CountDownScreenText.text = "The Lone Survivor \n Player " + Winner;
    //                    }

    //                    break;
    //                case GameModes.Torrentment:
    //                    break;
    //                default:
    //                    break;
    //            }
    //            break;
    //        default:
    //            break;
    //    }

    //    if (Input.GetButtonDown("p1_quit") || Input.GetButtonDown("p2_quit") || Input.GetButtonDown("p3_quit") || Input.GetButtonDown("p4_quit"))
    //    {
    //        Application.Quit();
    //    }
    //}

    //void LoadMenuComponets()
    //{

    //}
    //void LoadStartComponets()
    //{
    //    PlayerConnected = GameObject.Find("player_connected");
    //}
    //void ConvertMinutesToMatchTime()
    //{
    //    MatchTimer = Minutes * 60f;
    //}
    //public void ScoreLimitAchived(int Player, int Score)
    //{
    //    ScoreLimitReached = !ScoreLimitReached;
    //    Winner = Player.ToString();
    //    WinningScore = Score.ToString();
    //}

    //public bool ReturnPlayerOnlineStatesAI(int Player)
    //{
    //    switch (Player)
    //    {
    //        case 1:
    //            return isPlayer1;
    //        case 2:
    //            return isPlayer2;
    //        case 3:
    //            return isPlayer3;
    //        case 4:
    //            return isPlayer4;
    //        default:
    //            break;
    //    }

    //    return true;
    //}

    //void TestToSeeHowManyAreLive()
    //{
    //    PlayerCount = 0;
    //    if (isPlayer1Alive == true)
    //    {
    //        PlayerCount++;
    //    }
    //    if (isPlayer2Alive == true)
    //    {
    //        PlayerCount++;
    //    }
    //    if (isPlayer3Alive == true)
    //    {
    //        PlayerCount++;
    //    }
    //    if (isPlayer4Alive == true)
    //    {
    //        PlayerCount++;
    //    }

    //    if (PlayerCount <= 1)
    //    {
    //        GameState = GameStates.EndGame;
    //    }
    //}

    //void CanvasChanger()
    //{
    //    for (int i = 0; i < CanvasObjects.Length; i++)
    //    {
    //        CanvasObjects[i].SetActive(false);
    //    }

    //    switch (GameState)
    //    {
    //        case GameStates.none:
    //            break;
    //        case GameStates.Start:
    //            CanvasObjects[0].SetActive(true); //Start Menu
    //            break;
    //        case GameStates.Menus:
    //            break;
    //        case GameStates.Game:

    //            break;
    //        case GameStates.PreGame:
    //            CanvasObjects[2].SetActive(true);
    //            break;
    //        case GameStates.EndGame:
    //            CanvasObjects[2].SetActive(true);
    //            break;
    //        default:
    //            break;
    //    }
    //}
}
