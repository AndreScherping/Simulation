using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject gameMenu;
    public GameObject gameRules;
    public GameMenu player;

    private void Start()
    {
        player.GetComponent<CarController>().enabled = false;
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            gameRules.SetActive(false);
            player.GetComponent<CarController>().enabled = true;
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameMenu.SetActive(true);
            player.GetComponent<CarController>().enabled = false;
            Time.timeScale = 0;
        }
    }

    public void ContinueGame()
    {
        gameMenu.SetActive(false);
        player.GetComponent<CarController>().enabled = true;
        Time.timeScale = 1;
    }
}
