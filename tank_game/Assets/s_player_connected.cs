using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s_player_connected : MonoBehaviour
{
    float Timer = 5f;
    bool Started = false;

    public Text p1t, p2t, p3t, p4t;
    public Image p1i, p2i, p3i, p4i;
    public Color blue, red, yellow, green, black;

    GameManager gM;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        gM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ControllerEnabed(int player)
    {
        if (FindObjectOfType<GameManager>().GameState == GameManager.GameStates.Menus)
        {
            gameObject.SetActive(true);
            if (gM.isPlayer1)
            {
                p1t.color = blue;
                p1i.color = blue;
            }
            else
            {
                p1t.color = black;
                p1i.color = black;
            }

            if (gM.isPlayer2)
            {
                p2t.color = red;
                p2i.color = red;
            }
            else
            {
                p2t.color = black;
                p2i.color = black;
            }

            if (gM.isPlayer3)
            {
                p3t.color = yellow;
                p3i.color = yellow;
            }
            else
            {
                p3t.color = black;
                p3i.color = black;
            }

            if (gM.isPlayer4)
            {
                p4t.color = green;
                p4i.color = green;
            }
            else
            {
                p4t.color = black;
                p4i.color = black;
            }
        }
    }
}
