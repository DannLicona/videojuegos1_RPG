using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditosMenu : MonoBehaviour
{

    public void VolverAlMenu()
    {
        // Vuelve al menú principal
        SceneManager.LoadScene("Menu");
    }
}