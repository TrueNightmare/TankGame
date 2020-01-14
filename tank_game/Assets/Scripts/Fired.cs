using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fired : MonoBehaviour
{
    [Range(1,4)]
    public int Owner;

    float timer = 5f;
    float ShellSpeed = 10f;

    public Material Blue, Red, Yellow, Green;

    GameObject OwnerTank;

    GameManager gM;

    void Start()
    {
        gM = GameManager.Instance;
        switch (Owner)
        {
            case 1:
                GetComponent<Renderer>().material = Blue;
                OwnerTank = GameObject.Find("p_player_blue(Clone)");
                break;
            case 2:
                GetComponent<Renderer>().material = Red;
                OwnerTank = GameObject.Find("p_player_red(Clone)");
                break;
            case 3:
                GetComponent<Renderer>().material = Yellow;
                OwnerTank = GameObject.Find("p_player_yellow(Clone)");
                break;
            case 4:
                GetComponent<Renderer>().material = Green;
                OwnerTank = GameObject.Find("p_player_green(Clone)");
                break;
            default:
                break;
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        transform.position += transform.forward * Time.deltaTime * ShellSpeed;
    }

    void LateUpdate()
    {
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject Other = collision.gameObject;
        PlayerController Controller = Other.GetComponent<PlayerController>();

        if (Other.tag == "Player" && Controller.Player != Owner && Controller.isAlive)
        {
            Controller.Death();
            Controller.Score++;
            Controller.Lives--;

            //if (OwnerTank.GetComponent<s_playerController>().Score >= gM.ScoreLimit)
            //{
            //    gM.ScoreLimitAchived(Owner, OwnerTank.GetComponent<s_playerController>().Score);
            //}
        }
        Destroy(gameObject);
    }
}
