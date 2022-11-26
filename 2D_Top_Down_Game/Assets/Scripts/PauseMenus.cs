using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenus : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Music()
    {
        Debug.Log("Toggle");
    }

    public void Home()
    {
        PlayerStats.playerMaxHealth = 10;
        PlayerStats.playerDamage = 1;
        PlayerStats.playerFireRate = 2;
        PlayerStats.playerCritChance = 5;
        PlayerStats.playerClipSize = 6;
        PlayerStats.playerReloadTime = 1f;
        PlayerStats.playerPowerUpCooldown = 1f;
        Debug.Log(PlayerStats.playerMaxHealth);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
