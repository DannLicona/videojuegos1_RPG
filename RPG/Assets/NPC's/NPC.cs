using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject txtDialogo;
    public static int numVisitas;

    public Sprite proftxt1, proftxt2, proftxt3;

    // --- NUEVO: Añade esta línea ---
    // Arrastra aquí el sonido que quieres que suene al activarse el diálogo
    public AudioClip sonidoAparicionDialogo; 

    void Start()
    {
        txtDialogo.SetActive(false);
        numVisitas = 0;
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            // --- NUEVO: Añade esta comprobación ---
            // Si el diálogo NO estaba activo, reproduce el sonido.
            // Esto evita que el sonido se repita si el jugador
            // sale y entra rápido del trigger.
            if (txtDialogo.activeSelf == false && sonidoAparicionDialogo != null)
            {
                // Reproduce el sonido en la posición del NPC
                AudioSource.PlayClipAtPoint(sonidoAparicionDialogo, transform.position);
            }
            // ------------------------------------

            // Tu código original
            txtDialogo.SetActive(true);
            EscribeDialogo();
            numVisitas++;
        }
    }

    private void EscribeDialogo()
    {
        switch (numVisitas)
        {
            case 0:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = proftxt1;
                break;
            case 1:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = proftxt2;
                break;
            case 2:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = proftxt3;
                break;
            
            // --- Recomendación ---
            // Añade un 'default' para que no falle si 'numVisitas' es > 2
            default:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = proftxt3;
                break;
        }
    }
}