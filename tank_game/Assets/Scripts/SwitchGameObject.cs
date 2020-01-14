using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGameObject : MonoBehaviour
{
    public GameObject SwitchTo;
    public string[] Buttons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in Buttons)
        {
            if (Input.GetButtonDown(item))
            {
                SwitchTo.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}