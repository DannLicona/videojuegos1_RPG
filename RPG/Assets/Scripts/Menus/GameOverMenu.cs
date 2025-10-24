using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void Reintentar()
    {
        // Reinicia la escena actual del juego
        SceneManager.LoadScene("SampleScene");
    }

    public void VolverAlMenu()
    {
        // Vuelve al menú principal
        SceneManager.LoadScene("Menu");
    }
}
