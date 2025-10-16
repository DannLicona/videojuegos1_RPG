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


    void Start()
    {
        anchoVidasPlayer = fondoVida.GetComponent<RectTransform>().sizeDelta.x;
        haMuerto = false;
        vida = vidasINI;
        gameOver.SetActive(false);
    }

    public void TomarDaño(int daño)
    {
        if (vida > 0 && puedePerderVida == 1)
        {
            puedePerderVida = 0;
            vida -= daño;
            Debug.Log($"El jugador recibió {daño} de daño! Vida actual: {vida}");
            DibujaVida(vida);
        }

        if (vida <= 0 && !haMuerto)
        {
            haMuerto = true;
            StartCoroutine(EjecutaMuerte());
        }
    }

    private void DibujaVida(int vida)
    {
        RectTransform transformImagen = fondoVida.GetComponent<RectTransform>();
        transformImagen.sizeDelta = new Vector2(anchoVidasPlayer * (float)vida / (float)vidasINI, transformImagen.sizeDelta.y);
    }

    IEnumerator EjecutaMuerte()
    {
        yield return new WaitForSeconds(1.2f); // Tiempo para mostrar la pantalla Game Over
        gameOver.SetActive(true);
    }
}
