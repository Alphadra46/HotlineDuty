using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject MainMenu;

    public GameObject Game;

    public GameObject PauseMenu;

    public GameObject ControlsMenu;

    public AudioSource GameMusic;
    
    public AudioSource MenuMusic;
    
    public PlayerStats playerStats;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        
        Time.timeScale = 1f;
        MenuMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenu.activeSelf)
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                PauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        if (MainMenu.activeSelf)
            Game.SetActive(false);
        if (playerStats.isDead)
            Reload();

    }
    
    public void StartGame()
    {
        MainMenu.SetActive(false);
        Game.SetActive(true);
        MenuMusic.Stop();
        GameMusic.Play();
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
    
    public void ReturnToMenu()
    {
        
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        ControlsMenu.SetActive(false);
        Game.SetActive(false);
        MainMenu.SetActive(true);
    }
    
    public void Controls()
    {
        MainMenu.SetActive(false);
        ControlsMenu.SetActive(true);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    
}
