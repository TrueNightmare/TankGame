using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_MainMenuControls : MonoBehaviour
{
    [Header("MainMenu")]
    public GameObject MainMenu;

    [Header("Options")]
    public GameObject OptionsMenu;

    [Header("Play")]
    public GameObject PlayCanvas;

    [Header("Credits")]
    public GameObject Credits;

    [Header("Quit")]
    public GameObject QuitBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OptionsButton()
    {

    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
