using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fired : MonoBehaviour
{
    [Range(1,4)]
    public int Owner;

    float timer = 5f, ShellSpeed = 10f;

    public Material Blue, Red, Yellow, Green;

    void Start()
    {
        switch (Owner)
        {
            case 1:
                GetComponent<Renderer>().material = Blue;
                break;
            case 2:
                GetComponent<Renderer>().material = Red;
                break;
            case 3:
                GetComponent<Renderer>().material = Yellow;
                break;
            case 4:
                GetComponent<Renderer>().material = Green;
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
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<s_playerController>().Player != Owner)
            {
                collision.gameObject.GetComponent<s_playerController>().Death();
            }
        }

        Destroy(gameObject);
    }
}
