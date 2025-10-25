using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidasPlayer : MonoBehaviour
{
    public Image fondoVida;
    private float anchoVidasPlayer;
    public static int vida;
    public bool haMuerto;
    public GameObject gameOver;
    private const int vidasINI = 5;
    public static int puedePerderVida = 1;

    // --- NUEVO: Variables para el sonido ---
    public AudioClip sonidoDolor; // Arrastra tu sonido de daño aquí
    private AudioSource audioSource;
    // ------------------------------------


    void Start()
    {
        anchoVidasPlayer = fondoVida.GetComponent<RectTransform>().sizeDelta.x;
        haMuerto = false;
        vida = vidasINI;
        gameOver.SetActive(false);

        // --- NUEVO: Obtener el AudioSource ---
        audioSource = GetComponent<AudioSource>();
        // -----------------------------------
    }

    public void TomarDaño(int daño)
    {
        if (vida > 0 && puedePerderVida == 1)
        {
            // --- NUEVO: Reproducir sonido ---
            // Justo aquí, antes de perder la vida
            if (sonidoDolor != null && audioSource != null)
            {
                audioSource.PlayOneShot(sonidoDolor);
            }
            // ------------------------------

            puedePerderVida = 0;
            vida -= daño;
            Debug.Log($"El jugador recibio {daño} de daño! Vida actual: {vida}");
            DibujaVida(vida);
        }

        if (vida <= 0 && !haMuerto)
        {
            haMuerto = true;
            StartCoroutine(EjecutaMuerte());
        }
    }

    public void DibujaVida(int vida)
    {
        if (vida <= vidasINI)
        {
            RectTransform transformImagen = fondoVida.GetComponent<RectTransform>();
            transformImagen.sizeDelta = new Vector2(anchoVidasPlayer * (float)vida / (float)vidasINI, transformImagen.sizeDelta.y);
        }
    }

    IEnumerator EjecutaMuerte()
    {
        yield return new WaitForSeconds(1); // Puedes ajustar este tiempo si quieres
        SceneManager.LoadScene("GameOver");
    }
}