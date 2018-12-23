using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_playerController : MonoBehaviour
{
    [Range(1,4)]
    public int Player;

    public GameObject TankBody, Turret, TurretTurn, FirePoint, Spawner, Shell;

    public bool isAlive = false;

    public int Lives = 1, Score;

    public float movementSpeed = 5f, rotationSpeed = 500f, turretRotate = 250f;

    float RespawnTimer = 3f;

    string colour, controls;

    public Material Blue, Red, Yellow, Green, Dead;

    // Start is called before the first frame update
    void Start()
    {
        switch (Player)
        {
            case 1:
                colour = "blue";
                controls = "p1_";
                TankBody.gameObject.GetComponent<Renderer>().material = Blue;
                Turret.gameObject.GetComponent<Renderer>().material = Blue;
                break;
            case 2:
                colour = "red";
                controls = "p2_";
                TankBody.gameObject.GetComponent<Renderer>().material = Red;
                Turret.gameObject.GetComponent<Renderer>().material = Red;
                break;
            case 3:
                controls = "p3_";
                colour = "yellow";
                TankBody.gameObject.GetComponent<Renderer>().material = Yellow;
                Turret.gameObject.GetComponent<Renderer>().material = Yellow;
                break;
            case 4:
                controls = "p4_";
                colour = "green";
                TankBody.gameObject.GetComponent<Renderer>().material = Green;
                Turret.gameObject.GetComponent<Renderer>().material = Green;
                break;
            default:
                break;
        }
        Spawner = GameObject.Find(colour + "_spawnpoint");
        Spawner.GetComponent<s_spawnPlayer>().isPlayerAlive = false;
    }

    // Update is called once per frame
    void Update()
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

        Debug.Log(controls + "Horizontal");
    }

    public void Death()
    {
        TankBody.gameObject.GetComponent<Renderer>().material = Dead;
        Turret.gameObject.GetComponent<Renderer>().material = Dead;
    }

    public void Respawn()
    {

    }
}
