using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("SampleScene"); 
    }

    public void AbrirVolumen()
    {
        SceneManager.LoadScene("Volumen");
    }

    public void AbrirCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
}
