using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s_player_connected : MonoBehaviour
{
    [Header("Development Only")]
    public Text[] PlayerText = new Text[4];
    public Image[] PlayerImage = new Image[4];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPlayer1)
        {
            PlayerText[0].color = GameManager.Instance.PlayerColours[0];
            PlayerImage[0].color = GameManager.Instance.PlayerColours[0];
        }
        else
        {
            PlayerText[0].color = Color.black;
            PlayerImage[0].color = Color.black;
        }

        if (GameManager.Instance.isPlayer2)
        {
            PlayerText[1].color = GameManager.Instance.PlayerColours[1];
            PlayerImage[1].color = GameManager.Instance.PlayerColours[1];
        }
        else
        {
            PlayerText[1].color = Color.black;
            PlayerImage[1].color = Color.black;
        }

        if (GameManager.Instance.isPlayer3)
        {
            PlayerText[2].color = GameManager.Instance.PlayerColours[2];
            PlayerImage[2].color = GameManager.Instance.PlayerColours[2];
        }
        else
        {
            PlayerText[2].color = Color.black;
            PlayerImage[2].color = Color.black;
        }

        if (GameManager.Instance.isPlayer4)
        {
            PlayerText[3].color = GameManager.Instance.PlayerColours[3];
            PlayerImage[3].color = GameManager.Instance.PlayerColours[3];
        }
        else
        {
            PlayerText[3].color = Color.black;
            PlayerImage[3].color = Color.black;
        }

    }
}