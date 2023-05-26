using System.Net.Mime;
using UnityEngine;

public class QuitApp : MonoBehaviour
{

    void Update()
    {
        QuitGame();
    }

    void QuitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit app");
            Application.Quit();
        }
    }
}
