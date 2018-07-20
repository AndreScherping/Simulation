using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void Switch(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
