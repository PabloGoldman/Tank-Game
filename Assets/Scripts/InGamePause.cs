using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePause : MonoBehaviour
{
    [SerializeField] GameObject inGamePause;
    [SerializeField] GameObject optionsMenu;

    bool inPause = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!inPause)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
    
    public void Pause()
    {
        Debug.Log("pausa");
        Cursor.visible = true;
        Time.timeScale = 0;
        inGamePause.SetActive(true);
        inPause = true;
    }

    public void Resume()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        inGamePause.SetActive(false);
        optionsMenu.SetActive(false);
        inPause = false;
    }
}
