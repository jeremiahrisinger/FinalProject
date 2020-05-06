﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    Camera camera;
    bool gamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (gamePaused)
            {
                UnPause();
            }
            else
            {
                Pause();
            }
        }
    }

    public void UnPause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        camera.GetComponent<LookingDirection>().SetPause(false);
        gamePaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        camera.GetComponent<LookingDirection>().SetPause(true);
        gamePaused = true;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Title");
    }
}