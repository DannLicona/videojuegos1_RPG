using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalidaTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica que el objeto que colisiona sea el jugador (usa la etiqueta correcta)
        if (other.CompareTag("Player"))
        {
            // Carga la escena "Ganar"
            SceneManager.LoadScene("Ganar");
        }
    }
}
