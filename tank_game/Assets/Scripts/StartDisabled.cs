using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDisabled : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
