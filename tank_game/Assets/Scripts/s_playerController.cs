using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_playerController : MonoBehaviour
{
    [Range(1,5)]
    public int Player;

    public GameObject TankBody, Turret, TurretTurn, FirePoint, Spawner, Shell;

    public bool isAlive = false;

    public int Lives = 1, Score;

    public float movementSpeed = 5f, rotationSpeed = 500f, turretRotate = 250f;

    float RespawnTimer = 3f;

    string colour, controls;

    public Color Blue, Red, Yellow, Green, Dead;

    public Renderer Render;

    GameManager gM;

    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();
        switch (Player)
        {
            case 1:
                colour = "blue";
                controls = "p1_";
                TankBody.gameObject.GetComponent<Renderer>().material.color = Blue;
                Turret.gameObject.GetComponent<Renderer>().material.color = Blue;
                break;
            case 2:
                colour = "red";
                controls = "p2_";
                TankBody.gameObject.GetComponent<Renderer>().material.color = Red;
                Turret.gameObject.GetComponent<Renderer>().material.color = Red;
                break;
            case 3:
                controls = "p3_";
                colour = "yellow";
                TankBody.gameObject.GetComponent<Renderer>().material.color = Yellow;
                Turret.gameObject.GetComponent<Renderer>().material.color = Yellow;
                break;
            case 4:
                controls = "p4_";
                colour = "green";
                TankBody.gameObject.GetComponent<Renderer>().material.color = Green;
                Turret.gameObject.GetComponent<Renderer>().material.color = Green;
                break;
            case 5:
                Turret.gameObject.GetComponent<Renderer>().material.color = Dead;
                break;
            default:
                break;
        }
        if (gM.GameState == GameManager.GameStates.PreGame)
        {
            Spawner = GameObject.Find(colour + "_spawnpoint");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive && gM.GameState == GameManager.GameStates.Game)
        {
            if (Input.GetButtonDown(controls + "Fire"))
            {
                Shell.GetComponent<Fired>().Owner = Player;
                Instantiate(Shell, FirePoint.transform.position, TurretTurn.transform.rotation);
            }

            if (Input.GetAxis(controls + "Vertical") >= .9f || Input.GetAxis(controls + "Vertical") <= -.9f)
                transform.position += transform.forward * Time.deltaTime * movementSpeed * -Input.GetAxis(controls + "Vertical");

            if (Input.GetAxis(controls + "Horizontal") >= .2f || Input.GetAxis(controls + "Horizontal") <= -.25f)
                transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime * Input.GetAxis(controls + "Horizontal"), 0));

            if (Input.GetButton(controls + "Turret_Right"))
            {
                TurretTurn.transform.Rotate(new Vector3(0, turretRotate * Time.deltaTime * 1, 0));
            }
            if (Input.GetButton(controls + "Turret_Left"))
            {
                TurretTurn.transform.Rotate(new Vector3(0, turretRotate * Time.deltaTime * -1, 0));
            }
        }
        else if (isAlive == false && gM.GameState == GameManager.GameStates.Game)
        {
            RespawnTimer -= Time.deltaTime;
            if (RespawnTimer < 0)
            {
                Respawn();
            }
        }
        
    }

    public void Death()
    {
        TankBody.gameObject.GetComponent<Renderer>().material.color = Dead;
        Turret.gameObject.GetComponent<Renderer>().material.color = Dead;
        isAlive = false;
    }

    public void Respawn()
    {
        isAlive = true;
        RespawnTimer = 3f;
        switch (Player)
        {
            case 1:
                TankBody.gameObject.GetComponent<Renderer>().material.color = Blue;
                Turret.gameObject.GetComponent<Renderer>().material.color = Blue;
                break;
            case 2:
                TankBody.gameObject.GetComponent<Renderer>().material.color = Red;
                Turret.gameObject.GetComponent<Renderer>().material.color = Red;
                break;
            case 3:
                TankBody.gameObject.GetComponent<Renderer>().material.color = Yellow;
                Turret.gameObject.GetComponent<Renderer>().material.color = Yellow;
                break;
            case 4:
                TankBody.gameObject.GetComponent<Renderer>().material.color = Green;
                Turret.gameObject.GetComponent<Renderer>().material.color = Green;
                break;
            case 5:
                Turret.gameObject.GetComponent<Renderer>().material.color = Dead;
                break;
            default:
                break;
        }
        transform.position = Spawner.transform.position;
        transform.rotation = Spawner.transform.rotation;
    }
}
