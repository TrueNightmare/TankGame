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

    string colour;

    // Start is called before the first frame update
    void Start()
    {
        switch (Player)
        {
            case 1:
                colour = "blue";
                break;
            case 2:
                colour = "red";
                break;
            case 3:
                colour = "yellow";
                break;
            case 4:
                colour = "green";
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
        if (Input.GetButtonDown("Fire1"))
        {
            Shell.GetComponent<Fired>().Owner = Player;
            Instantiate(Shell, FirePoint.transform.position, transform.rotation);
        }
        if (Input.GetButton("Vertical"))
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed * Input.GetAxis("Vertical");
        }
        if (Input.GetButton("Horizontal"))
        {
            transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0));
        }
        if (Input.GetButton("Turret"))
        {
            TurretTurn.transform.Rotate(new Vector3(0, turretRotate * Time.deltaTime * -Input.GetAxis("Turret"), 0));
        }
    }
}
