using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_follow_players : MonoBehaviour
{
    public float[] padding;
    Vector3 Center = new Vector3(0, 0, 0);
    Vector3 StartPoint;
    public GameObject BluePlayer, RedPlayer, GreenPlayer, YellowPlayer;
    bool isBlue, isRed, isGreen, isYellow;

    // Start is called before the first frame update
    void Start()
    {
        StartPoint = transform.position;
        if (GameObject.Find("blue_spawnpoint") == true)
        {
            isBlue = true;
        }
        if (GameObject.Find("red_spawnpoint") == true)
        {
            isRed = true;
        }
        if (GameObject.Find("green_spawnpoint") == true)
        {
            isGreen = true;
        }
        if (GameObject.Find("yellow_spawnpoint") == true)
        {
            isYellow = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isBlue == true && BluePlayer == false)
        {
            BluePlayer = GameObject.Find("p_player_blue(Clone)");
        }
        if (isRed == true && RedPlayer == false)
        {
            BluePlayer = GameObject.Find("p_player_red(Clone)");
        }
        if (isGreen == true && GreenPlayer == false)
        {
            BluePlayer = GameObject.Find("p_player_Green(Clone)");
        }
        if (isYellow == true && YellowPlayer == false)
        {
            BluePlayer = GameObject.Find("p_player_Yellow(Clone)");
        }
    }

    void LateUpdate()
    {
        Vector3 centerPoint = GetCenterPoint();
    }

    Vector3 GetCenterPoint()
    {
        return Vector3.zero;
    }
}
