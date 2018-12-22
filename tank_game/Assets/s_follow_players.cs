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
        if (isBlue)
        {
            BluePlayer = GameObject.Find("p_player_blue(Clone)");
        }
    }
}
