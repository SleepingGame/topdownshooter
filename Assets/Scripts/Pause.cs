using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    bool pauseBool;
    public GameObject paused;
    void Start()
    {
        pauseBool = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        if (!pauseBool)
        {
            Time.timeScale = 0;
            paused.SetActive(true);
            pauseBool = true;
        }
        else
        {
            Time.timeScale = 1;
            paused.SetActive(false);
            pauseBool = false;
        }
    }
}
